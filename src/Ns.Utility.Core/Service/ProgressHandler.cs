using Ns.Utility.Framework.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Service
{
    public class ProgressHandler : NotificationHandler<string>
    {
        private readonly static Lazy<ProgressHandler> instance = new Lazy<ProgressHandler>(() => new ProgressHandler());
        public static ProgressHandler Instance { get { return instance.Value; } }

        public void Initialize()
        {
            messages.Clear();
        }
    }
}
