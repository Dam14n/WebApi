using DataLayer;

namespace WebService
{
	public class BaseService
	{
		private readonly ModelContext _context = new ModelContext();

		protected ModelContext GetContext { get; set; }
	}
}
