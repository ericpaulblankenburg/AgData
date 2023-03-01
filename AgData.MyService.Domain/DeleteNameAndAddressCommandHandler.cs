namespace AgData.MyService.Domain;
public class DeleteNameAndAddressCommandHandler
{
	private readonly IRepository _repository;
	private readonly RequestValidator _requestValidator;

	public DeleteNameAndAddressCommandHandler(IRepository repository, RequestValidator requestValidator)
	{
		_repository = repository;
		_requestValidator = requestValidator;
	}

	public async Task<ResponseContextBase> Handle(RequestContext<DeleteNameAndAddressCommand> requestContext)
	{
		Guard.IsNotNull(requestContext, nameof(requestContext));
		Guard.IsNotNull(requestContext.Request, nameof(requestContext.Request));

		var command = requestContext.Request;


		throw new NotImplementedException();
	}

}
