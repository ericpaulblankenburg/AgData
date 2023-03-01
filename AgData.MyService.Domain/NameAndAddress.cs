namespace AgData.MyService.Domain;
public class NameAndAddress
{
	[JsonProperty("id")]
	public string Identifier { get; set; }
	public string Name { get; set; }
	public string Address { get; set; }

}
