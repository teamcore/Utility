using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Ns.Utility.Web.Areas.Deployment.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace Ns.Utility.Web.Areas.Deployment
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

        public string Show()
        {
            return progress.Initialize();
        }
    }
}