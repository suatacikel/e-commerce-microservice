using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.API.Services
{
    public interface IDiscountService
    {
        Task<ResponseDto<List<Models.Discount>>> GetListAsync();
        Task<ResponseDto<Models.Discount>> GetByIdAsync(string id);
        Task<ResponseDto<Models.Discount>> GetByCodeAsync(string code);
        Task<ResponseDto<Models.Discount>> CreateAsync(Models.Discount discount);
        Task<ResponseDto<Models.Discount>> UpdateAsync(string id, Models.Discount discount);
        Task<ResponseDto<NoContentDto>> DeleteAsync(string id);
    }
}
