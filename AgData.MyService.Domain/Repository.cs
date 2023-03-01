namespace AgData.MyService.Domain;
public class Repository : IRepository
{
	public DbCollection<NameAndAddress> NamesAndAddresses { get; set; }

	public Repository(CosmosClient cosmosClient, string databaseName)
	{
		NamesAndAddresses = new DbCollection<NameAndAddress>(cosmosClient, databaseName, "namesandaddresses");

	}
	
}
