using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Application.Abstraction
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
        void Commit();
    }
}