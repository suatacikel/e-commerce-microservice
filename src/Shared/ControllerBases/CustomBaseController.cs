using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace Shared.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(ResponseDto<T> responseDto)
        {
            return new ObjectResult(responseDto)
            {
                StatusCode = responseDto.StatusCode
            };
        }
    }
}
