namespace ShrubsBudgetFinance.Services
{
	public interface IConfigService<T> 
	{
		IEnumerable<T> Get();
		void Insert(T entity);
		void Update(int id, T entity);
		void FindOne(int id);
		void Delete(int id);
	}
}
