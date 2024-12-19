using Microsoft.EntityFrameworkCore;
using ShrubsBudgetFinance.Models;

namespace ShrubsBudgetFinance.Data
{
	public class ConfigContext : DbContext
	{
		//Constructors
		public ConfigContext() { }
		public ConfigContext(DbContextOptions<ConfigContext> options) : base(options) { }

		//DbSets
		public DbSet<Config>? Configs { get; set; }
		public DbSet<IncomeBreakdown>? IncomeBreakdowns { get; set; }
		public DbSet<AccountNames>? AccountNamess { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=SKYTECHCOMPUTER;Database=shrubfinancebudgetdb;Integrated Security=true;Trusted_Connection=true;TrustServerCertificate=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Config>().HasData(
				new Config { TableId = 1, TableName = "IncomeBreakdown" },
				new Config { TableId = 2, TableName = "AccountNames" },
				new Config { TableId = 3, TableName = "AssetNames" },
				new Config { TableId = 4, TableName = "LiabilityNames" },
				new Config { TableId = 5, TableName = "AnnualBudget" },
				new Config { TableId = 6, TableName = "MonthlyExpenses" },
				new Config { TableId = 7, TableName = "MonthlyBudget" },
				new Config { TableId = 8, TableName = "Overview" }
				);

			modelBuilder.Entity<IncomeBreakdown>().HasData(
				new IncomeBreakdown { rowId = 1, rowName = "Gross Salary", monthlyValue = 0, yearlyValue = 0, ConfigId = 1},
				new IncomeBreakdown { rowId = 2, rowName = "Passive Investment Contribution", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 3, rowName = "Net Income", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 4, rowName = "Average Extra Income", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 5, rowName = "Total Gross Income", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 },
				new IncomeBreakdown { rowId = 6, rowName = "Net Total Income", monthlyValue = 0, yearlyValue = 0, ConfigId = 1 }
				);

			modelBuilder.Entity<AccountNames>().HasData(
				new AccountNames { rowId = 1, Type = "Checking Account", Nickname = "Monthly Budget", ConfigId = 2 },
				new AccountNames { rowId = 2, Type = "Billing Account", Nickname = "Spending Needs", ConfigId = 2 },
				new AccountNames { rowId = 3, Type = "Savings Account #1", Nickname = "Savings", ConfigId = 2 },
				new AccountNames { rowId = 4, Type = "Savings Account #2", Nickname = "Annual Budget", ConfigId = 2 },
				new AccountNames { rowId = 5, Type = "Savings Account #3", Nickname = "Other Bank(s) Total", ConfigId = 2 },
				new AccountNames { rowId = 6, Type = "Savings Account #4", Nickname = "Emergency Fund", ConfigId = 2 }
				);

			//modelBuilder.Entity<IncomeBreakdown>(entity =>
			//{
			//	entity.ToTable("IncomeBreakdown");
			//	entity.Property(e => e.rowName);
			//	entity.Property(e => e.monthlyValue);
			//});


			//OnModelCreatingPartial(modelBuilder);
		}

		//partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
