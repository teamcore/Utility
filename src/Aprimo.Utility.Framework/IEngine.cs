using System;
using Aprimo.Utility.Framework.Settings;
using Autofac;

namespace Aprimo.Utility.Framework
{
    public interface IEngine
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        IContainer Container { get; }

        /// <summary>
        /// Gets the builder.
        /// </summary>
        /// <value>
        /// The builder.
        /// </value>
        ContainerBuilder Builder { get; }

        /// <summary>
        /// Initialize components and plugins in the Aprimo.Utility.Framework environment.
        /// </summary>
        /// <param name="databaseIsConfigured">if set to <c>true</c> [database is configured].</param>
        void Initialize(bool databaseIsConfigured);

        /// <summary>
        /// Resets this instance.
        /// </summary>
        void Reset();

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        object Resolve(Type type);
    }
}
