using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace ShrubsBudgetFinance.Models
{
	public class Config
	{
		[Key]
		public int TableId { get; set; }
		public string? TableName { get; set; }

		public virtual ObservableCollectionListSource<IncomeBreakdown>? IncomeBreakdowns { get; set; }
	}
}
