using System.Threading.Tasks;
using MediatorSample.Domain.Entities;

namespace MediatorSample.Domain.Repositories
{
    public interface ICustomerRepository
    {
         Task CreateAsync(CustomerEntity entity);
    }
}