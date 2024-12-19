using Microsoft.CodeAnalysis.CSharp.Syntax;
using ShrubsBudgetFinance.Models;


namespace ShrubsBudgetFinance.Services
{
	public class FixedMonthlyCostsService
	{
		private IConfigService<MonthlyFixedExpenses> fixedCostService;

		public FixedMonthlyCostsService(IConfigService<MonthlyFixedExpenses> config) 
		{
			fixedCostService = config;
		}

		//GET (create)
		public async Task<List<MonthlyFixedExpenses>> GetFixedCosts()
		{
			var result = fixedCostService.Get();
			return result.ToList();
		}
		//POST (read)
		public async Task InsertFixedCost(MonthlyFixedExpenses fixedCost)
		{
			fixedCostService.Insert(fixedCost);
		}
		//PUT (update)
		public async Task UpdateFixedCost(int fixedCostId, MonthlyFixedExpenses fixedCost)
		{
			fixedCostService.Update(fixedCostId, fixedCost);
		}
		//DELETE (delete)
		public async Task DeleteFixedCost(int fixedCostId)
		{
			fixedCostService.Delete(fixedCostId);
		}
	}
}
