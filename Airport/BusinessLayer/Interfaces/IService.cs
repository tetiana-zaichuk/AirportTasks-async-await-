using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IService<T>
    {
        Task<bool> ValidationForeignIdAsync(T ob);

        Task<T> IsExistAsync(int id);

        Task<List<T>> GetAllAsync();
        
        Task<T> GetDetailsAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(int id);

        Task RemoveAllAsync();
    }
}
