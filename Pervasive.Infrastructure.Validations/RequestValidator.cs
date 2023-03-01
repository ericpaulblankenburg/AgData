namespace Pervasive.Infrastructure.Validations;
public class RequestValidator
{
	public IEnumerable<string> Validate<T>(T model)
	{
		Guard.IsNotNull(model, nameof(model));

		var errors = new List<string>();

		List<ValidationResult> validationResults = new();
		var validationContext = new ValidationContext(model, null, null);
		validationContext.MemberName = null;
		Validator.TryValidateObject(model, validationContext, validationResults, true);
		foreach (var validationResult in validationResults)
		{
			if (validationResult.ErrorMessage is not null)
			{
				errors.Add(validationResult.ErrorMessage);
			}
		}
		
		return errors;

	}

}
