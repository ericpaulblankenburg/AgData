using System.Linq;

namespace Pervasive.Infrastructure.Requests;
public class RequestContextBase
{
	public IEnumerable<SerializableClaim> Claims { get; set; }

	public RequestContextBase(IEnumerable<SerializableClaim> claims)
	{
		Claims = claims;

	}

	public RequestContextBase()
	{
		Claims = new List<SerializableClaim>();
	}

}
