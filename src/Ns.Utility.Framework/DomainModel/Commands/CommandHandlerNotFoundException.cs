using System;

namespace Ns.Utility.Framework.DomainModel.Commands
{
    public class CommandHandlerNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CommandHandlerNotFoundException(Type type)
            : base(string.Format("Command handler not found for command type: {0}", type))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerNotFoundException"/> class.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandResult">The command result.</param>
        public CommandHandlerNotFoundException(Type commandType, Type commandResult)
            : base(string.Format("Command handler not found for command type: {0}, and command result type: {1}", commandType, commandResult))
        {
        }
    }
}
