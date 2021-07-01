using Product.API.Model;
using System.Threading.Tasks;

namespace Product.API.Repository
{
    public interface IRepository<T> where T : EntityBase<T>
    {
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(string id, T item);
        Task DeleteAsync(string id);
    }
}
