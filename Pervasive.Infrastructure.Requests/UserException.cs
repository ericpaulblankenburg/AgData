namespace Pervasive.Infrastructure.Requests;
public class UserException : Exception
{
	public HttpStatusCode HttpStatusCode { get; set; }
	public IEnumerable<string> Errors { get; set; } = new List<string>();

	public UserException(HttpStatusCode httpStatusCode, string message) : base(message)
	{
		HttpStatusCode = httpStatusCode;
	}
	public UserException(HttpStatusCode httpStatusCode, string message, IEnumerable<string> errors) : base(message)
	{
		HttpStatusCode = httpStatusCode;
		Errors = errors;
	}

}

