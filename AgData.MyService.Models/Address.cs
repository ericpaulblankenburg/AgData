namespace AgData.MyService.Models;
public class Address
{
	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StreetNumberRequired")]
	public string StreetNumber { get; set; }

	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StreetNameRequired")]
	public string StreetName { get; set; }
	public string StreetAddress => $"{StreetNumber} {StreetName}";

	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "MuncipalityRequired")]
	public string Muncipality { get; set; }

	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CountrySubdivisionRequired")]
	public string CountrySubdivision { get; set; }

	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PostalCodeRequired")]
	public string PostalCode { get; set; }

	[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CountryCodeRequired")]
	public string CountryCode { get; set; }

}
