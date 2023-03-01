using System.Data.Common;

namespace AgData.MyService.Models;
public class AddNameAndAddressCommand
{
	public string Identifier { get; set; }

	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NameRequired")]
	[StringLength(50, MinimumLength = 1, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "NameRequired")]
	public string Name { get; set; }

	public AddNameAndAddressCommand()
	{
		Identifier = Guid.NewGuid().ToString().Replace("-", "");
	}

}
