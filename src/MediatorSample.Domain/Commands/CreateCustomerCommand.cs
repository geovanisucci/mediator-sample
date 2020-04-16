using Flunt.Validations;
using Flunt.Notifications;
using MediatorSample.Domain.Commands.Responses;
using MediatorSample.Domain.Core;
using MediatR;

namespace MediatorSample.Domain.Commands
{
    public class CreateCustomerCommand : Notifiable, ICommand, IRequest<CommandResult<CreateCustomerCommandResponse>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                 .Requires()
                 .HasMinLen(Name, 0, "Name", "Required.")
                 .HasMaxLen(Name, 150, "Name", "Must be less than 150.")
                 .HasMinLen(LastName, 0, "LastName", "Required.")
                 .HasMaxLen(LastName, 150, "LastName", "Must be less than 150.")
                 .IsEmail(Email, "Email", "Must be a valid e-mail.")
                 .HasMinLen(Email, 0, "Email", "Required.")

            );
        }
    }
}