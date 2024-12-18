using Microsoft.EntityFrameworkCore;
using ShrubsBudgetFinance.Models;

namespace ShrubsBudgetFinance.Data
{
	public partial class ConfigContext : DbContext
	{
		public ConfigContext() { }
		public ConfigContext(DbContextOptions<ConfigContext> options) : base(options) { }

		public DbSet<Config>? Configs { get; set; }
		public DbSet<IncomeBreakdown>? IncomeBreakdowns { get; set; }

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
				new IncomeBreakdown { rowId = 1, rowName = "Gross Salary", monthlyValue = 0, yearlyValue = 0, ConfigId = 1}
				);

			//modelBuilder.Entity<IncomeBreakdown>(entity =>
			//{
			//	entity.ToTable("IncomeBreakdown");
			//	entity.Property(e => e.rowName);
			//	entity.Property(e => e.monthlyValue);
			//});


			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
