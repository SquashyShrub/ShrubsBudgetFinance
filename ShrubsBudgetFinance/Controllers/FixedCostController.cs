using ShrubsBudgetFinance.Data;
using ShrubsBudgetFinance.Models;
using ShrubsBudgetFinance.Services;

namespace ShrubsBudgetFinance.Controllers
{
	public class FixedCostController : IConfigService<MonthlyFixedExpenses>
	{
		ConfigContext _context;
		public FixedCostController(ConfigContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			MonthlyFixedExpenses ord = _context.MonthlyFixedExpensess.Find(id);
			_context.MonthlyFixedExpensess.Remove(ord);
			_context.SaveChanges();
		}

		public MonthlyFixedExpenses FindOne(int id)
		{
			return _context.MonthlyFixedExpensess.Find(id);
		}

		public IEnumerable<MonthlyFixedExpenses> Get()
		{
			return _context.MonthlyFixedExpensess.ToList();
		}

		public void Insert(MonthlyFixedExpenses entity)
		{
			_context.MonthlyFixedExpensess.Add(entity);
			_context.SaveChanges();
		}

		public void Update(int id, MonthlyFixedExpenses entity)
		{
			var entityToUpdate = _context.MonthlyFixedExpensess.Find(id);
			entityToUpdate.Amount = entity.Amount;
			_context.SaveChanges();
		}
	}
}
