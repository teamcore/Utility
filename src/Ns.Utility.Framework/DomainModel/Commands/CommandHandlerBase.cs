using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ns.Utility.Framework.Data.Contract;

namespace Ns.Utility.Framework.DomainModel.Commands
{
    public class CommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected IRepository<Entity> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerBase&lt;TCommand&gt;"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CommandHandlerBase(IRepository<Entity> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Handle(TCommand command)
        {
            Entity entity = repository.Get(command.Id);
            Type commandType = command.GetType();
            IDictionary<string, PropertyInfo> commandProperties = commandType.GetProperties().ToDictionary(x => x.Name, y=> y);
            IDictionary<string, PropertyInfo> entityProperties = entity.GetSignatureProperties().ToDictionary(x => x.Name, y => y);

            foreach (KeyValuePair<string, PropertyInfo> commandProperty in commandProperties)
            {
                if(entityProperties.ContainsKey(commandProperty.Key))
                {
                    PropertyInfo property = entityProperties[commandProperty.Key];
                    if(property.CanWrite)
                        property.SetValue(entity, commandProperty.Value.GetValue(command, null), null);
                }
            }

            repository.Update(entity);
        }
    }

    public class CommandHandlerBase<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
        where TResult : class
    {
        protected IRepository<Entity> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerBase&lt;TCommand&gt;"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CommandHandlerBase(IRepository<Entity> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public TResult Handle(TCommand command)
        {
            Entity entity = repository.Get(command.Id);
            Type commandType = command.GetType();
            IDictionary<string, PropertyInfo> commandProperties = commandType.GetProperties().ToDictionary(x => x.Name, y => y);
            IDictionary<string, PropertyInfo> entityProperties = entity.GetSignatureProperties().ToDictionary(x => x.Name, y => y);

            foreach (KeyValuePair<string, PropertyInfo> commandProperty in commandProperties)
            {
                if (entityProperties.ContainsKey(commandProperty.Key))
                {
                    PropertyInfo property = entityProperties[commandProperty.Key];
                    if (property.CanWrite)
                    property.SetValue(property, commandProperty.Value.GetValue(commandProperty.Value, null), null);
                }
            }

            repository.Update(entity);
            return entity as TResult;
        }
    }
}
