using ShrubsBudgetFinance.Models;
using Microsoft.AspNetCore.Mvc;
using ShrubsBudgetFinance.Data;

//namespace ShrubsBudgetFinance.Controllers
//{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class IncomeBreakdownConroller : ControllerBase
//	{
//		public IncomeBreakdownConroller() { }


//		//GET (create)
//		[HttpGet]
//		public async Task<ActionResult<List<IncomeBreakdown>>> Get()
//		{
//			ConfigContext db = new ConfigContext();
//			return db.IncomeBreakdowns.ToList();
//		}

//		//POST (read)
//		[HttpPost]
//		public async Task<ActionResult<IncomeBreakdown>> Post (IncomeBreakdown income)
//		{
//			ConfigContext db = new ConfigContext();
//			db.IncomeBreakdowns.Add(income);
//			db.SaveChanges();
//			return Ok(income);
//		}

//		//PUT (update)
//		[HttpPut("{id}")]
//		public async Task<ActionResult<IncomeBreakdown>> Put (int id, IncomeBreakdown income)
//		{
//			using (ConfigContext db = new ConfigContext())
//			{
//				var existingIncome = await db.IncomeBreakdowns.FindAsync(id);
//				if (existingIncome == null)
//				{
//					return NotFound(); //404 not found response
//				}

//				//update the properties
//				existingIncome.monthlyValue = income.monthlyValue;
//				existingIncome.yearlyValue = income.yearlyValue;

//				await db.SaveChangesAsync();

//				return Ok(existingIncome);
//			}
//		}

//		//DELETE (delete)
//		[HttpDelete("{id}")]
//		public async Task<ActionResult<IncomeBreakdown>> Delete (int id)
//		{
//			ConfigContext db = new ConfigContext();
//			var income = await db.IncomeBreakdowns.FindAsync(id);
//			if (income == null)
//				return NotFound();
			
//			db.IncomeBreakdowns.Remove(income);
//			db.SaveChanges();

//			return NoContent();
//		}
//	}
//}
