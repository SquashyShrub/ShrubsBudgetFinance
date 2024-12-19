using ShrubsBudgetFinance.Data;
using ShrubsBudgetFinance.Models;
using ShrubsBudgetFinance.Services;

namespace ShrubsBudgetFinance.Controllers
{
	public class LiabilityController : IConfigService<LiabilityName>
	{
		private ConfigContext _context;
		public LiabilityController(ConfigContext context)
		{
			_context = context;
		}
		public void Delete(int id)
		{
			try
			{
				LiabilityName ord = _context.LiabilityNames.Find(id);
				_context.LiabilityNames.Remove(ord);
				_context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}
		public LiabilityName FindOne(int id)
		{
			return _context.LiabilityNames.Find(id);
		}

		public IEnumerable<LiabilityName> Get()
		{
			return _context.LiabilityNames.ToList();
		}

		public void Insert(LiabilityName entity)
		{
			_context.LiabilityNames.Add(entity);
			_context.SaveChanges();
		}

		public void Update(int id, LiabilityName entity)
		{
			var liabilityToUpdate = _context.LiabilityNames.Find(id);
			liabilityToUpdate.Nickname = entity.Nickname;
			_context.SaveChanges();
		}
	}
}
