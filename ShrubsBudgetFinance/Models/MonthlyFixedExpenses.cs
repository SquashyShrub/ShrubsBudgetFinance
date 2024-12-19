using System.ComponentModel.DataAnnotations;

namespace ShrubsBudgetFinance.Models
{
	public class MonthlyFixedExpenses
	{
		[Key]
		public int rowId { get; set; }
		public string? BudgetCategory { get; set; }
		public decimal Amount { get; set; }
		public double Percentage { get; set; }
		public int configId { get; set; }
		public Config? Config { get; set; }
	}
}
