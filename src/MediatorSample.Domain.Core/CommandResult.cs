using System.Collections.Generic;
using System.Net;
using Flunt.Notifications;

namespace MediatorSample.Domain.Core
{
   /// <summary>
    /// It provides a result command to a handler.
    /// </summary>
    public class CommandResult : ICommandResult
    {
        /// <summary>
        /// Indicate the success command result.
        /// </summary>
        /// <value></value>
        public bool Success { get; set; }
        /// <summary>
        /// Indicate the StatusCode result to this command.
        /// </summary>
        /// <value></value>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// The message result to this command.
        /// </summary>
        /// <value></value>
        public string Message { get; set; }
        /// <summary>
        /// The notifications to this command.
        /// Used when fail validations occur.
        /// </summary>
        /// <value></value>
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        /// <summary>
        /// Set the command result as succeeded.
        /// </summary>
        /// <param name="statusCode">The StatusCode result to this command</param>
        /// <param name="message">The message result to this command</param>
        /// <returns>A succeeded command result</returns>
        public static CommandResult Succeeded(HttpStatusCode statusCode, string message = null)
          => new CommandResult { Success = true, StatusCode = statusCode, Message = message };

        /// <summary>
        /// Set the command result as failed.
        /// </summary>
        /// <param name="statusCode">The StatusCode result to this command</param>
        /// <param name="message">The message result to this command</param>
        /// <param name="notifications">The fail notifications to this command.</param>
        /// <returns>A failed command result</returns>
        public static CommandResult Failed(HttpStatusCode statusCode, string message = null, IReadOnlyCollection<Notification> notifications = null)
      => new CommandResult { Success = false, StatusCode = statusCode, Message = message, Notifications = notifications };
    }

    /// <summary>
    /// It provides a result command to a handler with a generic response value.
    /// </summary>
    /// <typeparam name="CommandResponse"></typeparam>
    public class CommandResult<CommandResponse> : CommandResult
      where CommandResponse : ICommandResponse
    {
        /// <summary>
        /// The generic response value.
        /// </summary>
        /// <value></value>
        public CommandResponse Value { get; set; }

        /// <summary>
        /// Set the command result as succeeded.
        /// </summary>
        /// <param name="value">The generic response value.</param>
        /// <param name="statusCode">The StatusCode result to this command</param>
        /// <param name="message">The message result to this command</param>
        /// <returns>A succeeded command result with response value.</returns>
        public static CommandResult<CommandResponse> Succeeded(CommandResponse value, HttpStatusCode statusCode, string message = null)
       => new CommandResult<CommandResponse> { Value = value, Success = true, StatusCode = statusCode, Message = message };

        /// <summary>
        /// Set the command result as succeeded.
        /// </summary>
        /// <param name="statusCode">The StatusCode result to this command</param>
        /// <param name="message">The message result to this command</param>
        /// <returns>A succeeded command result with null response value</returns>
        public static new CommandResult<CommandResponse> Succeeded(HttpStatusCode statusCode, string message = null)
            => Succeeded(default(CommandResponse), statusCode, message);
        /// <summary>
        ///  Set the command result as failed.
        /// </summary>
        /// <param name="value">The generic response value.</param>
        /// <param name="statusCode">The StatusCode result to this command</param>
        /// <param name="message">The message result to this command</param>
        /// <param name="notifications">The fail notifications to this command.</param>
        /// <returns>A failed command result with response value.</returns>
        public static CommandResult<CommandResponse> Failed(CommandResponse value, HttpStatusCode statusCode, string message = null, IReadOnlyCollection<Notification> notifications = null)
            => new CommandResult<CommandResponse> { Value = value, Success = false, StatusCode = statusCode, Message = message, Notifications = notifications };

        /// <summary>
        /// Set the command result as failed.
        /// </summary>
        /// <param name="statusCode">The StatusCode result to this command</param>
        /// <param name="message">The message result to this command</param>
        /// <param name="notifications">The fail notifications to this command.</param>
        /// <returns>A failed command result with null response value.</returns>
        public static new CommandResult<CommandResponse> Failed(HttpStatusCode statusCode, string message = null, IReadOnlyCollection<Notification> notifications = null)
    => Failed(default(CommandResponse), statusCode, message, notifications);
    }
}