using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Framework.Notifications
{
    public class NotificationHandler<T> : IObservable<T>
    {
        protected List<IObserver<T>> observers;
        protected List<T> messages;

        public NotificationHandler()
        {
            observers = new List<IObserver<T>>();
            messages = new List<T>();
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                foreach (var message in messages)
                    observer.OnNext(message);
            }

            return new Unsubscriber<T>(observers, observer);
        }

        public void Update(T value)
        {
            messages.Add(value);
            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }
        }

        public void Complete()
        {
            foreach (var observer in observers)
                observer.OnCompleted();

            observers.Clear();
        }
    }
}
