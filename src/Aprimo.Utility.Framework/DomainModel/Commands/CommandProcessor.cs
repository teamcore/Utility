using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aprimo.Utility.Framework.DomainModel.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command.</param>
        public void Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            Validator.ValidateObject(command, new ValidationContext(command, null, null), true);

            var handlers = EngineContext.Current.Resolve<IEnumerable<ICommandHandler<TCommand>>>();
            if (handlers == null || !handlers.Any())
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            foreach (var handler in handlers)
            {
                handler.Handle(command);
            }
        }

        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            Validator.ValidateObject(command, new ValidationContext(command, null, null), true);

            var handlers = EngineContext.Current.Resolve<IEnumerable<ICommandHandler<TCommand, TResult>>>();
            if (handlers == null || !handlers.Any())
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            return handlers.Select(handler => handler.Handle(command)).FirstOrDefault();
        }

        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <param name="resultHandler">The result handler.</param>
        public void Process<TCommand, TResult>(TCommand command, Action<TResult> resultHandler) where TCommand : ICommand
        {
            resultHandler(Process<TCommand, TResult>(command));
        }
    }
}
