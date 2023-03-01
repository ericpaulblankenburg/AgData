namespace Pervasive.Infrastructure.CosmosDb;
public static class DbCollectionExtensions
{
	public static async Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> queryable, int retries = 3) where T : new()
	{
		return await RetryService.Execute<T>(async () =>
		{
			queryable = queryable.Take(1);

			using (var iterator = queryable.ToFeedIterator())
			{
				var response = await iterator.ReadNextAsync();
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					return response.Resource.FirstOrDefault();
				}

				return new T();

			}

		}, retries);

	}

	public static async Task<IEnumerable<T>> ToListAsync<T>(this IQueryable<T> queryable, int retries = 3) where T : new()
	{
		return await RetryService.Execute<IEnumerable<T>>(async () =>
		{
			using (var iterator = queryable.ToFeedIterator())
			{
				var response = await iterator.ReadNextAsync();
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					return response.Resource;
				}

				return new List<T>();

			}

		}, retries);

	}

}
