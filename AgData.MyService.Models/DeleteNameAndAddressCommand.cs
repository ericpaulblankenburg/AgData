namespace AgData.MyService.Models;
public class DeleteNameAndAddressCommand
{
	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "IdentifierRequired")]
	public string Identifier { get; set; }


}
