using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Ns.Utility.Web.Areas.Deployment.Models;
using Microsoft.AspNet.SignalR.Hubs;
using Ns.Utility.Core.Service;

namespace Ns.Utility.Web.Areas.Deployment.Hubs
{
    [HubName("Progress")]
    public class ProgressHub : Hub
    {
        ProgressTicker progress;

        public ProgressHub() : this(ProgressTicker.Instance)
        {

        }
        public ProgressHub(ProgressTicker progress)
        {
            this.progress = progress;
        }

        public void Initialize()
        {
            progress.Initialize();
        }
    }
}