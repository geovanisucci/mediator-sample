using System.Threading.Tasks;
using MediatorSample.Domain.Entities;
using MediatorSample.Domain.Repositories;
using MediatorSample.Infra.Data.Context;

namespace MediatorSample.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MediatorSampleContext _dbContext;
        
        public CustomerRepository(MediatorSampleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(CustomerEntity entity)
        {
            _dbContext.Customers.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}