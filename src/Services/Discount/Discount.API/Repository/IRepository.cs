using Discount.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.API.Repository
{
    public interface IRepository<T> where T : EntityBase<T>
    {
        Task<List<T>> GetListAsync(RequestQuery query);
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(string id, T item);
        Task DeleteAsync(string id);
    }
}
