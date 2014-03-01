using Autofac;

namespace Ns.Utility.Framework.Dependency
{
    public interface IDependencyManager
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        void Register(ContainerBuilder builder);
    }
}
