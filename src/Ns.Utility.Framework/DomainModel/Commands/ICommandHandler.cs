namespace Ns.Utility.Framework.DomainModel.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        void Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand
    {
        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        TResult Handle(TCommand command);
    }
}