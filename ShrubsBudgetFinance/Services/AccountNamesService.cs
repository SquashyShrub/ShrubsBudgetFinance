using ShrubsBudgetFinance.Models;

namespace ShrubsBudgetFinance.Services
{
	public class AccountNamesService
	{
		private IConfigService<AccountNames> accountService;

		public AccountNamesService(IConfigService<AccountNames> config)
		{
			accountService = config;
		}

		//GET (create)
		public async Task<List<AccountNames>> GetAccountNames()
		{
			var result = accountService.Get();
			return result.ToList();
		}
		//POST (read)
		public async Task InsertAccountName(AccountNames account)
		{
			accountService.Insert(account);
		}
		//PUT (update)
		public async Task UpdateAccountName(int accountId, AccountNames account)
		{
			accountService.Update(accountId, account);
		}
		//DELETE (delete)
		public async Task DeleteAccountName(int accountId)
		{
			accountService.Delete(accountId);
		}
	}
}
