using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Invoicings;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BarberBoss.infrastructure.DataAccess.Repositories
{
    internal class InvoicingRepository : IInvoicingWriteOnlyRepository, IInvoicingReadOnlyRepository, IInvoicingUpdateOnlyRepository
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

        public async Task<bool> Delete(long id)
        {
            var result = await _dbcontext.invoicings.FirstOrDefaultAsync(invoicing => invoicing.Id == id);
            if (result is null)
            {
                return false;
            }
            _dbcontext.invoicings.Remove(result);
            return true;
        }

        public async Task<List<Invoicing>> Get()
        {
            return await _dbcontext.invoicings.AsNoTracking().ToListAsync();
        }

        public async Task<Invoicing?> GetById(long id)
        {
            return await _dbcontext.invoicings.FirstOrDefaultAsync(invoicing => invoicing.Id == id);
        }

        public async Task<List<Invoicing>> GetByMonth(DateOnly date)
        {
            var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;
            var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
            var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);
            var result = await 
                _dbcontext
                .invoicings
                .AsNoTracking()
                .Where(invoicing => invoicing.Data >= startDate && invoicing.Data <= endDate)
                .OrderBy(invoicing => invoicing.Data)
                .ToListAsync();
            return result;
        }

        public void Update(Invoicing invoicing)
        {
            _dbcontext.invoicings.Update(invoicing);
        }
        
    }
}

