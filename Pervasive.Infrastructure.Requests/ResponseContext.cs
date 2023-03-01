namespace Pervasive.Infrastructure.Requests;
public class ResponseContext<T> : ResponseContextBase
{
	public T Response { get; set; }

	public ResponseContext() : base() => Response = default;
	
	public ResponseContext(T response) : base() => Response = response;

	public ResponseContext(string statusMessage, T response) : base(statusMessage) => Response = response;

	public ResponseContext(HttpStatusCode statusCode, string statusMessage, T response, IEnumerable<KeyValuePair<string, string>> errors) : base(statusMessage, errors) => Response = response;


}
