namespace Pervasive.Infrastructure.Requests;

/// <summary>
/// System.Security.Claims.Claim has issues when serializing to Azure Storage Queues
/// because of the requirement to base64 encode the messages.
/// </summary>
/// <returns></returns>
public class SerializableClaim
{
	public string Type { get; set; }
	public string Value { get; set; }

	public SerializableClaim(string type, string value)
	{
		Type = type;
		Value = value;
	}

	public SerializableClaim()
	{

	}

}
