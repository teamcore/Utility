using System;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Ns.Utility.Framework.Dependency;
using Ns.Utility.Framework.Settings;
using Autofac;

namespace Ns.Utility.Framework
{
    public class EngineContext
    {
        private static IDependencyManager dependency;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceInit, bool databaseIsConfigured, IDependencyManager dependencyManager)
        {
            dependency = dependencyManager;

            if(Singleton<IEngine>.Instance == null || forceInit)
            {
                var config = ConfigurationManager.GetSection("NsConfig") as Config;
                Debug.WriteLine("Configuring engine {0}", DateTime.Now);
                Singleton<IEngine>.Instance = CreateEngineInstance(config, dependencyManager);
                Debug.WriteLine("Initialising engine {0}", DateTime.Now);
                Singleton<IEngine>.Instance.Initialize(databaseIsConfigured);
            }

            return Singleton<IEngine>.Instance;
        }

        public static IContainer Build()
        {
            return Current.Build();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public static void Reset()
        {
            Singleton<IEngine>.Instance.Reset();
        }

        /// <summary>
        /// Replaces the specified engine.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        /// <summary>
        /// Creates the engine instance.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="dependencyManager">The dependency manager.</param>
        /// <returns></returns>
        public static IEngine CreateEngineInstance(Config config, IDependencyManager dependencyManager)
        {
            if (config != null && !string.IsNullOrEmpty(config.EngineType))
            {
                var engineType = Type.GetType(config.EngineType);
                if (engineType == null)
                {
                    throw new ConfigurationErrorsException("The type '" + config.EngineType + "' could not be found. Please check the configuration at /configuration/ns/engine[@engineType] or check for missing assemblies.");
                }

                if (!typeof(IEngine).IsAssignableFrom(engineType))
                {
                    throw new ConfigurationErrorsException("The type '" + engineType + "' doesn't implement 'Ns.Utility.Framework.IEngine' and cannot be configured in /configuration/ns/engine[@engineType] for that purpose.");
                }

                return Activator.CreateInstance(engineType) as IEngine;
            }

            return new WebEngine(new ContainerBuilder(), dependencyManager);
        }

        /// <summary>
        /// Gets the current.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if(Singleton<IEngine>.Instance == null)
                {
                    Initialize(false, true, dependency);
                }

                return Singleton<IEngine>.Instance;
            }
        }
    }
}
