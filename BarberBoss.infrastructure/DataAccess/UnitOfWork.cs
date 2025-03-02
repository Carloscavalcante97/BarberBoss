using BarberBoss.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BarberBossDbContext _dbcontext;    
        public UnitOfWork(BarberBossDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task Commit()=> await _dbcontext.SaveChangesAsync();
    }
}
