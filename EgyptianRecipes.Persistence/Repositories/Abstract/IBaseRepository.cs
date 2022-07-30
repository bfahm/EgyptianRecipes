using System.Collections.Generic;
using System.Threading.Tasks;

namespace EgyptianRecipes.Persistence.Repositories.Abstract
{
    public interface IBaseRepository<T>
    {
        Task<T> AddAsync(T item);
        Task<List<T>> GetAllAsync();
        ValueTask<T> GetByIdAsync(long Id);
        Task RemoveAsync(T item);
        Task<T> UpdateAsync(T item);
    }
}
