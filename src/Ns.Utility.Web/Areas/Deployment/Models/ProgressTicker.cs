using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Ns.Utility.Core.Service;
using Ns.Utility.Framework.Notifications;
using Ns.Utility.Web.Areas.Deployment.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Ns.Utility.Web.Areas.Deployment.Models
{
    public class ProgressTicker : IObserver<string>
    {
        private readonly static Lazy<ProgressTicker> instance = new Lazy<ProgressTicker>(() => new ProgressTicker(GlobalHost.ConnectionManager.GetHubContext<ProgressHub>().Clients));
        private Timer timer;
        private NotificationHandler<string> publisher;
        private IDisposable cancellation;
        private ProgressTicker(IHubConnectionContext clients)
        {
            Clients = clients;
            timer = new Timer(LocalUpdate, null, 600000, 600000);
        }

        public static ProgressTicker Instance { get { return instance.Value; } }
        private IHubConnectionContext Clients { get; set; }
        public void Initialize()
        {
            ProgressHandler.Instance.Subscribe(this);
        }
        
        private void LocalUpdate(object progress)
        {
            OnNext("Progress Health Checkup.");
        }

        private void Update(string message)
        {
            Clients.All.show(message);
        }

        public virtual void Subscribe(NotificationHandler<string> publisher)
        {
            cancellation = publisher.Subscribe(this);
            this.publisher = publisher;
        }

        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
        }

        public void OnCompleted()
        {
            Update("Completed.");
        }

        public void OnError(Exception error)
        {
            Update("Error: " + error.Message);
        }

        public void OnNext(string value)
        {
            Update(value);
        }
    }
}