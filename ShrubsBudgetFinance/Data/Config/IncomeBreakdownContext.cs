using Microsoft.EntityFrameworkCore;
using ShrubsBudgetFinance.Models;
using ConfigModel = ShrubsBudgetFinance.Models.Config; //Using alias because I get an error otherwise -> Conflict with Config.razor?

namespace ShrubsBudgetFinance.Data.Config
{
	public class IncomeBreakdownContext : DbContext
	{
		public DbSet<ConfigModel>? Configs { get; set; }
		public DbSet<IncomeBreakdown>? IncomeBreakdowns { get; set; }
	}
}
