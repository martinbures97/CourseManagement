using CourseManagement.Application.Abstraction;
using CourseManagement.Application.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Identity
{
    public sealed class AspnetIdentityUserService : IUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AspnetIdentityUserService(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<string> CreateUserAsync(string userName, string password, CancellationToken cancellationToken)
        {
            var role = new IdentityRole("Admin");
            await _roleManager.CreateAsync(role);

            var user = new IdentityUser(userName);
            cancellationToken.ThrowIfCancellationRequested();
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = new Dictionary<string, string>();
                result.Errors.ToList().ForEach((item) =>
                {
                    errors.Add(item.Code, item.Description);
                });

                throw new ValidationException(errors);
            }

            await _userManager.AddToRoleAsync(user, role.Name);

            return user.Id;
        }
    }
}