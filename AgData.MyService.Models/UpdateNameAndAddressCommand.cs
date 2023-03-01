namespace AgData.MyService.Models;
public class UpdateNameAndAddressCommand
{
	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "IdentifierRequired")]
	public string Identifier { get; set; }

	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NameRequired")]
	[StringLength(50, MinimumLength = 1, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NameRequired")]
	public string Name { get; set; }


}
