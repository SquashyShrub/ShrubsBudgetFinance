using System.ComponentModel.DataAnnotations;

namespace ShrubsBudgetFinance.Models
{
	public class LiabilityName
	{
		[Key]
		public int rowId { get; set; }
		public string Type { get; set; }
		public string Nickname { get; set; }
		public int ConfigId { get; set; }
		public Config? Config { get; set; }
	}
}
