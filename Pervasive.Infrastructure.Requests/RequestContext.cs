namespace Pervasive.Infrastructure.Requests;
public class RequestContext<T> : RequestContextBase
{
	public T Request { get; set; }

	public RequestContext(IEnumerable<SerializableClaim> claims, T request) : base(claims)
	{
		Request = request;
	}

	public RequestContext()
	{
		Request = default(T);
	}

}
