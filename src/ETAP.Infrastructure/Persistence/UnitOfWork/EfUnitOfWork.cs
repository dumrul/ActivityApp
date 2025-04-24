using ETAP.Application.Interfaces;

namespace ETAP.Infrastructure.Persistence.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly EtapDbContext _context;

        public EfUnitOfWork(EtapDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}