namespace Pervasive.Infrastructure.Requests;
public class ResponseContextBase
{
	public string StatusMessage { get; set; }
	public IEnumerable<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();

	public ResponseContextBase(string statusMessage) => StatusMessage = StatusMessage;

	public ResponseContextBase(string statusMessage, IEnumerable<KeyValuePair<string, string>> errors) => (StatusMessage, Errors) = (statusMessage, errors);

	public ResponseContextBase()
	{

	}

}

