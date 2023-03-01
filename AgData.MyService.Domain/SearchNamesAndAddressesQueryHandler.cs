namespace AgData.MyService.Domain;
public class SearchNamesAndAddressesQueryHandler
{
	private readonly IRepository _repository;

	public SearchNamesAndAddressesQueryHandler(IRepository repository)
	{
		_repository = repository;
	}

	public async Task<ResponseContext<IEnumerable<SearchNameAndAddressQueryResponse>>> Handle(RequestContext<SearchNamesAndAddressesQuery> requestContext)
	{
		Guard.IsNotNull(requestContext, nameof(requestContext));
		Guard.IsNotNull(requestContext.Request, nameof(requestContext.Request));

		var query = requestContext.Request;

		throw new NotImplementedException();

	}

}
