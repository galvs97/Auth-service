
using System.Threading.Tasks;

namespace AuthValidator.DbContext 
{
    public interface IDynamoDBContext<T> where T : class
    {
        Task SaveAsync(T item);
        Task<T> GetAsync(string key);
        Task UpdateAsync(T item);
        Task DeleteAsync(string key);
        Task<List<T>> GetAllAsync();
    }
}
