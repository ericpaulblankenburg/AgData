namespace Pervasive.Infrastructure.CosmosDb;
public class RetryService
{
	public static async Task<TResult> Execute<TResult>(Func<Task<TResult>> func, int numberOfRetries = 3)
	{
		Exception exception = new Exception();

		foreach (var attempt in Enumerable.Range(0, numberOfRetries))
		{
			try
			{
				return await func();
			}
			catch (CosmosException ex)
			{
				exception = ex;

				if(ex.StatusCode == HttpStatusCode.NotFound)
				{
					return await Task.FromResult(default(TResult));
				}

				if (ex.StatusCode != HttpStatusCode.Gone &&
					ex.StatusCode != HttpStatusCode.RequestTimeout &&
					ex.StatusCode != HttpStatusCode.TooManyRequests &&
					ex.StatusCode != (HttpStatusCode) 449 &&
					ex.StatusCode != HttpStatusCode.ServiceUnavailable)
				{
					throw;
				}
			}

		}

		throw exception;

	}

}
