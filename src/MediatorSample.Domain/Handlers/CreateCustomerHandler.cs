using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatorSample.Domain.Commands;
using MediatorSample.Domain.Commands.Responses;
using MediatorSample.Domain.Core;
using MediatorSample.Domain.Entities;
using MediatorSample.Domain.Repositories;
using MediatR;

namespace MediatorSample.Domain.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CommandResult<CreateCustomerCommandResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CommandResult<CreateCustomerCommandResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (!request.Valid)
            {
                if (request.Notifications.Any())
                    return CommandResult<CreateCustomerCommandResponse>.Failed(HttpStatusCode.PreconditionFailed, "Pre condition failed", request.Notifications);
            }

            var entityCreated = new CustomerEntity();
            entityCreated.New(request.Name, request.LastName, request.Email);
            await _customerRepository.CreateAsync(entityCreated);

            return CommandResult<CreateCustomerCommandResponse>.Succeeded(new CreateCustomerCommandResponse()
            {
                Id = entityCreated.Id.ToString(),
                Name = entityCreated.Name,
                LastName = entityCreated.LastName,
                Email = entityCreated.Email
            }, HttpStatusCode.Created);
        }
    }
}
