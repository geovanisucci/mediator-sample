using MediatorSample.Domain.Core;

namespace MediatorSample.Domain.Commands.Responses
{
    public class CreateCustomerCommandResponse : ICommandResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}