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
		public DbSet<AssetName>? AssetNames { get; set; }
		public DbSet<LiabilityName>? LiabilityNames { get; set; }


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

			modelBuilder.Entity<AssetName>().HasData(
				new AssetName { rowId = 1, Type = "Passive Investment Contribution", Nickname = "My 401k", ConfigId = 3 },
				new AssetName { rowId = 2, Type = "Active Investment Contribution", Nickname = "Roth IRA", ConfigId = 3 },
				new AssetName { rowId = 3, Type = "Other Investment #1", Nickname = "Crypto", ConfigId = 3 },
				new AssetName { rowId = 4, Type = "Other Investment #2", Nickname = "Charles Schwabb", ConfigId = 3 },
				new AssetName { rowId = 5, Type = "Other Income #1", Nickname = "Rental Property Income", ConfigId = 3 },
				new AssetName { rowId = 6, Type = "Other Income #2", Nickname = "Dividends", ConfigId = 3 }
				);

			modelBuilder.Entity<LiabilityName>().HasData(
				new LiabilityName { rowId = 1, Type = "Rent/Mortgage", Nickname = "Home Mortgage", ConfigId = 4 },
				new LiabilityName { rowId = 2, Type = "Vehicle Loan #1", Nickname = "Toyota Corolla", ConfigId = 4 },
				new LiabilityName { rowId = 3, Type = "Vehicle Loan #2", Nickname = "", ConfigId = 4 },
				new LiabilityName { rowId = 4, Type = "Vehicle Loan #3", Nickname = "", ConfigId = 4 },
				new LiabilityName { rowId = 5, Type = "Loan/Debt #1", Nickname = "Student Loans", ConfigId = 4 },
				new LiabilityName { rowId = 6, Type = "Loan/Debt #2", Nickname = "Angel Load", ConfigId = 4 },
				new LiabilityName { rowId = 7, Type = "Loan/Debt #3", Nickname = "", ConfigId = 4 },
				new LiabilityName { rowId = 8, Type = "Credit Card #1", Nickname = "Discover Card", ConfigId = 4 },
				new LiabilityName { rowId = 9, Type = "Credit Card #2", Nickname = "Chase Card", ConfigId = 4 },
				new LiabilityName { rowId = 10, Type = "Credit Card #3", Nickname = "Capital One Card", ConfigId = 4 }
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
