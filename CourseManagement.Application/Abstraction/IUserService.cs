using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Abstraction
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(string userName, string password, CancellationToken cancellationToken);
    }
}