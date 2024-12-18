namespace ShrubsBudgetFinance.Services
{
	public interface IConfigService<T>
	{
		IEnumerable<T> Get();
		void Insert(T entity);
		void Update(int id, T entity);
		T FindOne(int id);
		void Delete(int id);
	}
}
