﻿using Pervasive.Infrastructure.Validations;

namespace AgData.MyService.Domain;
public class UpdateNameAndAddressCommandHandler
{
	private readonly IRepository _repository;
	private readonly RequestValidator _requestValidator;

	public UpdateNameAndAddressCommandHandler(IRepository repository, RequestValidator requestValidator)
	{
		_repository = repository;
		_requestValidator = requestValidator;
	}

	public async Task<ResponseContextBase> Handle(RequestContext<UpdateNameAndAddressCommand> requestContext)
	{
		Guard.IsNotNull(requestContext, nameof(requestContext));
		Guard.IsNotNull(requestContext.Request, nameof(requestContext.Request));
		var command = requestContext.Request;

		var errors = _requestValidator.Validate(command);
		if (errors.Any())
		{
			throw new UserException(System.Net.HttpStatusCode.BadRequest, null, errors);
		}




		throw new NotImplementedException();
	}

}
