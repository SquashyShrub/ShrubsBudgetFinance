using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShrubsBudgetFinance.Models;
using ShrubsBudgetFinance.Data;

namespace ShrubsBudgetFinance.Services
{
	public class ConfigService : IConfigService<IncomeBreakdown>
	{
		private ConfigContext _context;
		public ConfigService(ConfigContext context)
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

		public void FindOne(int id)
		{
			throw new NotImplementedException();
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

		public void Update(int id, IncomeBreakdown entity)
		{
			try
			{
				var local = _context.Set<IncomeBreakdown>().Local.FirstOrDefault(entry => entry.rowId.Equals(entry.rowId));
				if (local != null)
				{
					_context.Entry(local).State = EntityState.Modified;
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
