using ShrubsBudgetFinance.Components.Pages.Config;
using System.ComponentModel.DataAnnotations;

namespace ShrubsBudgetFinance.Models
{
	public class IncomeBreakdown
	{
		[Key]
		public int rowId { get; set; }
		public string? rowName { get; set; }
		public decimal monthlyValue { get; set; }
		public decimal yearlyValue { get; set; }
		public int ConfigId { get; set; }

		public virtual Config? Config { get; set; }
	}
}
