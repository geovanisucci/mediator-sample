using MediatorSample.Domain.Entities;
using MediatorSample.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MediatorSample.Infra.Data.Context
{
    public class MediatorSampleContext : DbContext
    {
        public MediatorSampleContext(DbContextOptions<MediatorSampleContext> options) : base(options) { }

        public DbSet<CustomerEntity> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}