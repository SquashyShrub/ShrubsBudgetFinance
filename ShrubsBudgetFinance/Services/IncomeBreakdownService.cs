using ShrubsBudgetFinance.Models;

namespace ShrubsBudgetFinance.Services
{
	
	public class IncomeBreakdownService
	{
		private IConfigService<IncomeBreakdown> incomeService;

		public IncomeBreakdownService(IConfigService<IncomeBreakdown> config)
		{			
			incomeService = config;
		}

		//GET (create)
		public async Task<List<IncomeBreakdown>> GetIncomeBreakdowns()
		{
			//var result = await _httpClient.GetFromJsonAsync<List<IncomeBreakdown>>("https://localhost:7014/api/DataGrid");
			//return result;
			var result = incomeService.Get();
			return result.ToList();
		}
		//POST (read)
		public async Task InsertIncome(IncomeBreakdown income)
		{
			incomeService.Insert(income);
		}
		//PUT (update)
		public async Task UpdateIncome(int incomeId, IncomeBreakdown income)
		{
			incomeService.Update(incomeId, income);
		}
		//DELETE (delete)
		public async Task DeleteIncome(int incomeId)
		{
			incomeService.Delete(incomeId);
		}
	}
}
