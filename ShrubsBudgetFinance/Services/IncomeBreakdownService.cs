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
			//await _httpClient.PostAsJsonAsync<IncomeBreakdown>($"https://localhost:7105/api/DataGrid/", income);
			//return income;
			configService.Insert(income);
		}
		//PUT (update)
		public async Task UpdateIncome(int incomeId, IncomeBreakdown income)
		{
			//HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"https://localhost:7105/api/DataGrid/{incomeId}", updatedIncome);
			//return updatedIncome;
			configService.Update(incomeId, income);
		}
		//DELETE (delete)
		public async Task DeleteIncome(int incomeId)
		{
			//HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:7105/api/DataGrid/{incomeId}");
			//return true;
			configService.Delete(incomeId);
		}
	}
}
