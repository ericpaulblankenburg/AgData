namespace Pervasive.Infrastructure.CosmosDb;
public class DbCollection<T> where T : new()
{
	protected readonly CosmosClient _cosmosClient;
	protected readonly string _databaseName;
	protected readonly string _containerName;
	private Container _container => _cosmosClient.GetDatabase(_databaseName).GetContainer(_containerName);

	public DbCollection(CosmosClient cosmosClient, string databaseName, string containerName)
	{
		_cosmosClient = cosmosClient;
		_databaseName = databaseName;
		_containerName = containerName;

	}

	public async Task<T> CreateItemAsync(T item, int retries = 3, params string[] partitionKeyValues)
	{
		return await RetryService.Execute<T>(async () =>
		{
			var itemResponse = await _container.CreateItemAsync(item, BuildParitionKey(partitionKeyValues));
			return itemResponse.Resource;
		}, retries);

	}

	public async Task<T> DeleteItemAsync(string key, int retries = 3, params string[] partitionKeyValues)
	{
		return await RetryService.Execute<T>(async () =>
		{
			var itemResponse = await _container.DeleteItemAsync<T>(key, BuildParitionKey(partitionKeyValues));
			return itemResponse.Resource;
		}, retries);

	}

	public async Task<T> PatchItemAsync(string key, List<PatchOperation> operations, int retries = 3, params string[] partitionKeyValues)
	{
		return await RetryService.Execute<T>(async () =>
		{
			var itemResponse = await _container.PatchItemAsync<T>(key, BuildParitionKey(partitionKeyValues), operations);
			return itemResponse.Resource;
		}, retries);

	}

	public async Task<T> ReplaceItemAsync(string key, T item, int retries = 3, params string[] partitionKeyValues)
	{
		return await RetryService.Execute<T>(async () =>
		{
			var itemResponse = await _container.ReplaceItemAsync(item, key, BuildParitionKey(partitionKeyValues));
			return itemResponse.Resource;
		}, retries);

	}

	public async Task<T> ReadItemAsync(string key, int retries = 3, params string[] partitionKeyValues)
	{
		return await RetryService.Execute<T>(async () =>
		{
			try
			{
				var itemResponse = await _container.ReadItemAsync<T>(key, BuildParitionKey(partitionKeyValues));
				return itemResponse.Resource;
			}
			catch(CosmosException ex)
			{
				if(ex.StatusCode != HttpStatusCode.NotFound)
				{
					throw;
				}

				return default(T);
			}

		}, retries);

	}

	public async Task<T> UpsertAsync(string key, T item, int retries = 3, params string[] partitionKeyValues)
	{
		return await RetryService.Execute<T>(async () =>
		{
			var itemResponse = await _container.UpsertItemAsync(item, BuildParitionKey(partitionKeyValues));
			return itemResponse.Resource;
		}, retries);

	}

	public IOrderedQueryable<T> AsQuerable()
	{
		return _container.GetItemLinqQueryable<T>(false);

	}

	private PartitionKey BuildParitionKey(string[] values)
	{
		PartitionKeyBuilder partitionKeyBuilder = new();
		foreach(var value in values)
		{
			partitionKeyBuilder.Add(value);

		}
		return partitionKeyBuilder.Build();

	}

}
