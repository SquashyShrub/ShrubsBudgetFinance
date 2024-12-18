using ShrubsBudgetFinance.Models;

namespace ShrubsBudgetFinance.Services
{
	
	public class IncomeBreakdownService
	{
		private HttpClient _httpClient;
		private IConfigService<IncomeBreakdown> configService;

		public IncomeBreakdownService(HttpClient httpClient, IConfigService<IncomeBreakdown> config)
		{
			_httpClient = httpClient;
			configService = config;

		}

		//GET (create)
		public async Task<List<IncomeBreakdown>> GetIncomeBreakdowns()
		{
			//var result = await _httpClient.GetFromJsonAsync<List<IncomeBreakdown>>("https://localhost:7014/api/DataGrid");
			//return result;
			var result = configService.Get();
			return result.ToList();
		}
		//POST (read)
		public async Task InsertIncome(IncomeBreakdown income)
		{
			configService.Insert(income);
		}
		//PUT (update)
		public async Task UpdateIncome(int incomeId, IncomeBreakdown income)
		{
			configService.Update(incomeId, income);
		}
		//DELETE (delete)
		public async Task DeleteIncome(int incomeId)
		{
			configService.Delete(incomeId);
		}
	}
}
