namespace MediatorSample.Domain.Core
{
    /// <summary>
    /// ICommand contract.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Validate the command.
        /// Applies the Fail Fast Validations with Flunt library in this command.
        /// </summary>
        void Validate();
    }
}