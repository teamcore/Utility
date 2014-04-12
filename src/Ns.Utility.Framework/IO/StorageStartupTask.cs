using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ns.Utility.Framework.Settings;
using Ns.Utility.Framework.Tasks;

namespace Ns.Utility.Framework.IO
{
    public class StorageStartupTask : IStartupTask
    {
        private readonly IConfigurationProvider<FileSystemSettings> provider;
        
        public StorageStartupTask()
        {
            provider = EngineContext.Current.Resolve<IConfigurationProvider<FileSystemSettings>>();
        }

        #region IStartupTask Members

        public void Execute()
        {
            if (provider.Settings.IsDefaultOrEmpty())
            {
                var settings = FileSystemSettings.Default();
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

        #endregion
    }
}
