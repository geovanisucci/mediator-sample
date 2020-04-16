using System.Collections.Generic;
using Flunt.Notifications;

namespace MediatorSample.Domain.Core
{
    public class PreConditionResponse
    {
        public string Message { get; private set; }
        public IReadOnlyCollection<Notification> Validation { get; private set; }

        public static PreConditionResponse New(string message, IReadOnlyCollection<Notification> validation) => new PreConditionResponse()
        {
            Message = message,
            Validation = validation
        };
    }
}