using ShrubsBudgetFinance.Models;

namespace ShrubsBudgetFinance.Services
{
	public class AssetNameService
	{
		private IConfigService<AssetName>? assetService;

		public AssetNameService(IConfigService<AssetName> config)
		{
			assetService = config;
		}

		//GET (create)
		public async Task<List<AssetName>> GetAssetNames()
		{
			var result = assetService.Get();
			return result.ToList();
		}
		//POST (read)
		public async Task InsertAsset(AssetName asset)
		{
			assetService.Insert(asset);
		}
		//PUT (update)
		public async Task UpdateAsset(int assetId, AssetName asset)
		{
			assetService.Update(assetId, asset);
		}
		//DELETE (delete)
		public async Task DeleteAsset(int assetId)
		{
			assetService.Delete(assetId);
		}

	}
}
