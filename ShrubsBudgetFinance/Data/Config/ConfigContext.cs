using Microsoft.EntityFrameworkCore;
using ShrubsBudgetFinance.Models;
using ConfigModel = ShrubsBudgetFinance.Models.Config; //Using alias because I get an error otherwise -> Conflict with Config.razor?

namespace ShrubsBudgetFinance.Data.Config
{
	public class ConfigContext : DbContext
	{
		public DbSet<ConfigModel>? Configs { get; set; }
		public DbSet<IncomeBreakdown>? IncomeBreakdowns { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=SKYTECHCOMPUTER;Database=shrubfinancebudgetdb;Integrated Security=true;Trusted_Connection=true;TrustServerCertificate=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ConfigModel>().HasData(
				new ConfigModel { TableId = 1, TableName = "IncomeBreakdown" },
				new ConfigModel { TableId = 2, TableName = "AccountNames" },
				new ConfigModel { TableId = 3, TableName = "AssetNames" },
				new ConfigModel { TableId = 4, TableName = "LiabilityNames" },
				new ConfigModel { TableId = 5, TableName = "AnnualBudget" },
				new ConfigModel { TableId = 6, TableName = "MonthlyExpenses" },
				new ConfigModel { TableId = 7, TableName = "MonthlyBudget" },
				new ConfigModel { TableId = 8, TableName = "Overview" }
				);

			modelBuilder.Entity<IncomeBreakdown>().HasData(
				new IncomeBreakdown { rowId = 1, rowName = "GrossSalary", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 2, rowName = "PassiveContribution", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 3, rowName = "NetIncome", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 4, rowName = "AvgExtraIncome", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 5, rowName = "GrossTotalIncome", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 6, rowName = "NetTotalIncome", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 }
				);
		}
	}
}
