using BarberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.infrastructure.DataAccess
{
    internal class BarberBossDbContext : DbContext
    {
        public BarberBossDbContext(DbContextOptions options): base(options) { }

        public DbSet<Invoicing> invoicings { get; set; }
    }
}
