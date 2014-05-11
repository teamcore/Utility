using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Ns.Utility.Web.Areas.Deployment.Models
{
    public class ProgressTicker
    {
        private readonly static Lazy<ProgressTicker> instance = new Lazy<ProgressTicker>(() => new ProgressTicker(GlobalHost.ConnectionManager.GetHubContext<ProgressHub>().Clients));
        private Timer timer;
        private ProgressTicker(IHubConnectionContext clients)
        {
            Clients = clients;
            timer = new Timer(LocalUpdate, null, 5000, 5000);
        }

        public static ProgressTicker Instance { get { return instance.Value; } }
        private IHubConnectionContext Clients { get; set; }
        public string Initialize()
        {
            return "Started...";
        }


        private void LocalUpdate(object progress)
        {
            Update("Tick...");
        }

        public void Update(string progress)
        {
            Clients.All.show(progress);
        }
    }
}