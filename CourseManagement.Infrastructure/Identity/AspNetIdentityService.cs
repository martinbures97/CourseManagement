using CourseManagement.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CourseManagement.Infrastructure.Identity
{
    public sealed class AspNetIdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetIdentityService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
    }
}