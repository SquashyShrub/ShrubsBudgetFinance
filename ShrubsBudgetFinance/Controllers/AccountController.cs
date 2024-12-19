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
	public class AccountController : IConfigService<AccountNames>
	{
		private ConfigContext _context;
		public AccountController(ConfigContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			try
			{
				AccountNames ord = _context.AccountNamess.Find(id);
				_context.AccountNamess.Remove(ord);
				_context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}

		public AccountNames FindOne(int id)
		{
			return _context.AccountNamess.Find(id);
		}

		public IEnumerable<AccountNames> Get()
		{
			try
			{
				return _context.AccountNamess.ToList();
			}
			catch
			{
				throw;
			}
		}

		public void Insert(AccountNames entity)
		{
			try
			{
				_context.AccountNamess.Add(entity);
				_context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}

		public void Update(int id, AccountNames account)
		{
			try
			{
				var accountNameToUpdate = _context.AccountNamess.Find(id);
				if (accountNameToUpdate != null)
				{
					accountNameToUpdate.Nickname = account.Nickname;
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
