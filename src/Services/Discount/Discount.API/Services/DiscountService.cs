using Discount.API.Models;
using Discount.API.Repository;
using Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.API.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepository<Models.Discount> _discountRepository;

        public DiscountService(IRepository<Models.Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<ResponseDto<NoContentDto>> DeleteAsync(string id)
        {
            await _discountRepository.DeleteAsync(id);
            return ResponseDto<NoContentDto>.Success(200);
        }

        public async Task<ResponseDto<List<Models.Discount>>> GetListAsync()
        {
            var results = await _discountRepository.GetListAsync(new RequestQuery());
            return ResponseDto<List<Models.Discount>>.Success(results, 200);
        }

        public async Task<ResponseDto<Models.Discount>> GetByCodeAsync(string code)
        {
            var request = new RequestQuery { WhereClause = $"code ={code}" };
            var results = await _discountRepository.GetListAsync(request);
            return ResponseDto<Models.Discount>.Success(results.FirstOrDefault(), 200);
        }

        public async Task<ResponseDto<Models.Discount>> GetByIdAsync(string id)
        {
            var result = await _discountRepository.GetAsync(id);
            return ResponseDto<Models.Discount>.Success(result, 200);
        }

        public async Task<ResponseDto<Models.Discount>> UpdateAsync(string id, Models.Discount discount)
        {
            var result = await _discountRepository.UpdateAsync(id, discount);
            return ResponseDto<Models.Discount>.Success(result, 200);
        }

        public async Task<ResponseDto<Models.Discount>> CreateAsync(Models.Discount discount)
        {
            var result = await _discountRepository.CreateAsync(discount);
            return ResponseDto<Models.Discount>.Success(result, 200);
        }
    }
}
