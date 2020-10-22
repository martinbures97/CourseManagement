using CourseManagement.Application.Abstraction;
using CourseManagement.Domain;
using CourseManagement.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManagement.Infrastructure.Persistence
{
    public sealed class CourseManagementDbContext : DbContext, IDbContextQueryAccessor
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IIdentityService _identityService;

        public CourseManagementDbContext(
            IDateTimeService dateTimeService,
            IIdentityService identityService,
            DbContextOptions<CourseManagementDbContext> options) : base(options)
        {
            _dateTimeService = dateTimeService;
            _identityService = identityService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureLayer).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries<IEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity is IAddableEntity)
                        {
                            entry.Property(nameof(IAddableEntity.CreatedBy)).CurrentValue = _identityService.UserId;
                            entry.Property(nameof(IAddableEntity.CreatedOn)).CurrentValue = _dateTimeService.Now;
                        }
                        break;

                    case EntityState.Modified:
                        if (entry.Entity is IUpdatableEntity)
                        {
                            entry.Property(nameof(IUpdatableEntity.UpdatedBy)).CurrentValue = _identityService.UserId;
                            entry.Property(nameof(IUpdatableEntity.UpdatedOn)).CurrentValue = _dateTimeService.Now;
                        }
                        break;

                    case EntityState.Deleted:
                        if (entry.Entity is ISoftDeletableEntity softDeletableEntity)
                        {
                            Entry(softDeletableEntity).State = EntityState.Modified;
                            entry.Property(nameof(ISoftDeletableEntity.DeletedBy)).CurrentValue = _identityService.UserId;
                            entry.Property(nameof(ISoftDeletableEntity.DeletedOn)).CurrentValue = _dateTimeService.Now;
                        }
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<TEntity> GetQueryable<TEntity>()
            where TEntity : class, IEntity
        {
            return Set<TEntity>().AsQueryable().AsNoTracking();
        }

        private DbSet<Course> Courses { get; }
        private DbSet<Student> Students { get; }
        private DbSet<Teacher> Teachers { get; }
        private DbSet<CourseStudent> CourseStudents { get; }
    }
}