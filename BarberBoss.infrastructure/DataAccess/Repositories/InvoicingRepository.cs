using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Invoicings;

namespace BarberBoss.infrastructure.DataAccess.Repositories
{
    internal class InvoicingRepository : IInvoicingWriteOnlyRepository
    {

        private readonly BarberBossDbContext _dbcontext;
        public InvoicingRepository(BarberBossDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task Add(Invoicing invoicing)
        {
            await _dbcontext.invoicings.AddAsync(invoicing);
        }
    }
}

