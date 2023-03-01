namespace AgData.MyService.Api.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("myservice")]
	public class MyServiceController : PervasiveControllerBase
	{
		/// <summary>
		/// 
		/// I don't put any application logic in the controller.
		/// This will allow us to easily replace the controller with something else, e.g.,
		/// a set of Azure Functions, gRPC services, etc.
		/// 
		/// </summary>
		/// <param name="handler"></param>
		/// <param name="command"></param>
		/// <returns></returns>


		[HttpPost]
		public async Task<ResponseContextBase> Add([FromServices] AddNameAndAddressCommandHandler handler, [FromBody] AddNameAndAddressCommand command)
		{
			//
			// package the request and the claims from the token so that it's queueable, if needed
			//
			var requestContext = new RequestContext<AddNameAndAddressCommand>()
			{
				Claims = ListClaims(),
				Request = command
			};

			return await handler.Handle(requestContext);

		}

		[HttpDelete]
		public async Task<ResponseContextBase> Delete([FromServices] DeleteNameAndAddressCommandHandler handler, [FromBody] DeleteNameAndAddressCommand command)
		{
			var requestContext = new RequestContext<DeleteNameAndAddressCommand>()
			{
				Claims = ListClaims(),
				Request = command
			};

			return await handler.Handle(requestContext);

		}

		[HttpPut]
		public async Task<ResponseContextBase> Update([FromServices] UpdateNameAndAddressCommandHandler handler, [FromBody] UpdateNameAndAddressCommand command)
		{
			var requestContext = new RequestContext<UpdateNameAndAddressCommand>()
			{
				Claims = ListClaims(),
				Request = command
			};

			return await handler.Handle(requestContext);

		}

		[HttpPost]
		[Route("search")]
		public async Task<ResponseContext<IEnumerable<SearchNameAndAddressQueryResponse>>> Search([FromServices] SearchNamesAndAddressesQueryHandler handler, [FromBody] SearchNamesAndAddressesQuery query)
		{
			var requestContext = new RequestContext<SearchNamesAndAddressesQuery>()
			{
				Claims = ListClaims(),
				Request = query
			};

			return await handler.Handle(requestContext);

		}

	}

}

