using System.ComponentModel.DataAnnotations.Schema;
using MediatorSample.Domain.Core;

namespace MediatorSample.Domain.Entities
{
    public class CustomerEntity : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }


        public void New(string name, string lastName, string email)
        {
            NewId();
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}