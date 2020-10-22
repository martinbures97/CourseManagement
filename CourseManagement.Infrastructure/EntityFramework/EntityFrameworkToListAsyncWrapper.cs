using CourseManagement.Application.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.EntityFramework
{
    public class EntityFrameworkToListAsyncWrapper : IToListAsyncWrapper
    {
        public Task<List<TResult>> ToListAsync<TResult>(IQueryable<TResult> query, CancellationToken cancellationToken)
        {
            return query.ToListAsync(cancellationToken);
        }
    }
}