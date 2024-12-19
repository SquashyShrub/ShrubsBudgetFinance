using ShrubsBudgetFinance.Data;
using ShrubsBudgetFinance.Models;
using ShrubsBudgetFinance.Services;

namespace ShrubsBudgetFinance.Controllers
{
	public class AssetController : IConfigService<AssetName>
	{
		private ConfigContext _context;
		public AssetController(ConfigContext context)
		{
			_context = context;
		}

		public void Delete(int id)
		{
			try
			{
				AssetName ord = _context.AssetNames.Find(id);
				_context.AssetNames.Remove(ord);
				_context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}
		public AssetName FindOne(int id)
		{
			return _context.AssetNames.Find(id);
		}

		public IEnumerable<AssetName> Get()
		{
			try
			{
				return _context.AssetNames.ToList();
			}
			catch
			{
				throw;
			}
		}
		public void Insert(AssetName entity)
		{
			try
			{
				_context.AssetNames.Add(entity);
				_context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}
		public void Update(int id, AssetName asset)
		{
			try
			{
				var assetToUpdate = _context.AssetNames.Find(id);
				if (assetToUpdate != null)
				{
					assetToUpdate.Nickname = asset.Nickname;
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
