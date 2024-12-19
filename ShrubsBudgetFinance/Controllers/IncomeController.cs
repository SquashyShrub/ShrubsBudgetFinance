using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShrubsBudgetFinance.Models;
using ShrubsBudgetFinance.Data;
using ShrubsBudgetFinance.Services;

namespace ShrubsBudgetFinance.Controllers
{
	public class IncomeController : IConfigService<IncomeBreakdown>
	{
		private ConfigContext _context;
		public IncomeController(ConfigContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			try
			{
				IncomeBreakdown ord = _context.IncomeBreakdowns.Find(id);
				_context.IncomeBreakdowns.Remove(ord);
				_context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}

		public IncomeBreakdown FindOne(int id)
		{
			return _context.IncomeBreakdowns.Find(id);
		}

		public IEnumerable<IncomeBreakdown> Get()
		{
			try
			{
				return _context.IncomeBreakdowns.ToList();
			}
			catch
			{
				throw;
			}
		}

		public void Insert(IncomeBreakdown entity)
		{
			try
			{
				_context.IncomeBreakdowns.Add(entity);
				_context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}

		public void Update(int id, IncomeBreakdown income)
		{
			try
			{
				var incomeToUpdate = _context.IncomeBreakdowns.Find(id);
				if (incomeToUpdate != null)
				{
					incomeToUpdate.monthlyValue = income.monthlyValue;
					incomeToUpdate.yearlyValue = income.yearlyValue;
					_context.SaveChanges();
				}
			}
			catch
			{
				throw;
			}
		}
	}

}
