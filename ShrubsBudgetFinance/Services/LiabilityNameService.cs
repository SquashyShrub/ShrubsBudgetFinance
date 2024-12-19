using ShrubsBudgetFinance.Models;


namespace ShrubsBudgetFinance.Services
{
	public class LiabilityNameService
	{
		private IConfigService<LiabilityName> liabilityService;

		public LiabilityNameService(IConfigService<LiabilityName> config)
		{
			liabilityService = config;
		}

		//GET (create)
		public async Task<List<LiabilityName>> GetLiabilityNames()
		{
			var result = liabilityService.Get();
			return result.ToList();
		}
		//POST (read)
		public async Task InsertLiability(LiabilityName liability)
		{
			liabilityService.Insert(liability);
		}
		//PUT (update)
		public async Task UpdateLiability(int id, LiabilityName liability)
		{
			liabilityService.Update(id, liability);
		}
		//DELETE (delete)
		public async Task DeleteLiability(int id)
		{
			liabilityService.Delete(id);
		}
	}
}
