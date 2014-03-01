using System;
using System.Collections.Generic;

namespace Ns.Utility.Framework.DomainModel.Commands
{
    public interface ICommandProcessor
    {
        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <param name="command">The command.</param>
        void Process<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        TResult Process<TCommand, TResult>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="command">The command.</param>
        /// <param name="resultHandler">The result handler.</param>
        void Process<TCommand, TResult>(TCommand command, Action<TResult> resultHandler) where TCommand : ICommand;
    }
}