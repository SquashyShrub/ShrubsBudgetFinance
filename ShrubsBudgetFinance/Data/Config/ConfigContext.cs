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
		public DbSet<MonthlyFixedExpenses>? MonthlyFixedExpensess { get; set; }


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

			modelBuilder.Entity<MonthlyFixedExpenses>().HasData(
				new MonthlyFixedExpenses { rowId = 1, BudgetCategory = "Annual Budget", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 2, BudgetCategory = "Active Investment Contribution", Amount = 0, Percentage = 0, configId = 6 },

				//Housing
				new MonthlyFixedExpenses { rowId = 3, BudgetCategory = "Housing", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 4, BudgetCategory = "Rent/Mortgage", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 5, BudgetCategory = "Renters/Home Insurance", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 6, BudgetCategory = "HOA Fees", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 7, BudgetCategory = "Electric", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 8, BudgetCategory = "Gas", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 9, BudgetCategory = "Water", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 10, BudgetCategory = "Waste", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 11, BudgetCategory = "Internet & Phone Bill", Amount = 0, Percentage = 0, configId = 6 },

				//Vehicles
				new MonthlyFixedExpenses { rowId = 12, BudgetCategory = "Vehicle #1", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 13, BudgetCategory = "Monthly Payment", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 14, BudgetCategory = "Insurance", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 15, BudgetCategory = "Vehicle #2", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 16, BudgetCategory = "Monthly Payment", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 17, BudgetCategory = "Insurance", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 18, BudgetCategory = "Vehicle #3", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 19, BudgetCategory = "Monthly Payment", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 20, BudgetCategory = "Insurance", Amount = 0, Percentage = 0, configId = 6 },

				//Loans/Debts
				new MonthlyFixedExpenses { rowId = 21, BudgetCategory = "Loan/Debt #1", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 22, BudgetCategory = "Loan/Debt #2", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 23, BudgetCategory = "Loan/Debt #3", Amount = 0, Percentage = 0, configId = 6 },

				//Subscriptions
				new MonthlyFixedExpenses { rowId = 24, BudgetCategory = "Streaming Subscriptions", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 25, BudgetCategory = "Gym Membership", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 26, BudgetCategory = "Music Subscriptions", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 27, BudgetCategory = "Shopping Subscriptions", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 28, BudgetCategory = "TV Subscriptions", Amount = 0, Percentage = 0, configId = 6 },	
				new MonthlyFixedExpenses { rowId = 29, BudgetCategory = "Other Subscriptions", Amount = 0, Percentage = 0, configId = 6 },

				//Contributions
				new MonthlyFixedExpenses { rowId = 30, BudgetCategory = "Billing Account Contribution", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 31, BudgetCategory = "Savings Contribution", Amount = 0, Percentage = 0, configId = 6 },

				//Other
				new MonthlyFixedExpenses { rowId = 32, BudgetCategory = "Other #1", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 33, BudgetCategory = "Other #2", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 34, BudgetCategory = "Other #3", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 35, BudgetCategory = "Other #4", Amount = 0, Percentage = 0, configId = 6 },
				new MonthlyFixedExpenses { rowId = 36, BudgetCategory = "Other #5", Amount = 0, Percentage = 0, configId = 6 }
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
