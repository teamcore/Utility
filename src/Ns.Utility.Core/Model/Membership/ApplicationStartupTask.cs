using Ns.Utility.Framework;
using Ns.Utility.Framework.Settings;
using Ns.Utility.Framework.Tasks;

namespace Ns.Utility.Core.Model.Membership
{
    public class ApplicationStartupTask : IStartupTask
    {
        private readonly IConfigurationProvider<ApplicationSettings> provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationStartupTask"/> class.
        /// </summary>
        public ApplicationStartupTask()
        {
            provider = EngineContext.Current.Resolve<IConfigurationProvider<ApplicationSettings>>();
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public void Execute()
        {
            if (provider.Settings == null)
            {
                var settings = ApplicationSettings.Default();
                provider.Save(settings);
            }
        }

        public void Reset()
        {
        }

        public int Order
        {
            get { return -1000; }
        }
    }
}
