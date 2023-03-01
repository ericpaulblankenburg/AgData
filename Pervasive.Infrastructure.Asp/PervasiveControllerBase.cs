namespace Pervasive.Infrastructure.Asp
{
	public class PervasiveControllerBase : ControllerBase
	{
		protected List<SerializableClaim> ListClaims()
		{
			return User.Claims.Select(m => new SerializableClaim(m.Type, m.Value)).ToList();
		}

	}

}
