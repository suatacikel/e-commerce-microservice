using Microsoft.AspNetCore.Http;

namespace Shared.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
