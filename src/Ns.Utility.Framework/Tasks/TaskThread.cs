using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Ns.Utility.Framework.Tasks
{
    /// <summary>
    /// Represents task thread
    /// </summary>
    public class TaskThread : IDisposable
    {
        private Timer timer;
        private bool disposed;
        private readonly IList<Task> tasks = new List<Task>();

        public TaskThread()
        {
            tasks = new List<Task>();
            Seconds = 1 * 60;
        }

        public TaskThread(string name, string description)
        {
            Name = name;
            Description = description;
            tasks = new List<Task>();
            Seconds = 1 * 60;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; protected set; }

        /// <summary>
        /// Gets or sets the interval in seconds at which to run the tasks
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get; set; }

        /// <summary>
        /// Get a datetime when thread has been started
        /// </summary>
        /// <value>
        /// The started.
        /// </value>
        public DateTime? Started { get; protected set; }

        /// <summary>
        /// Get a value indicating whether thread is running
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; protected set; }

        /// <summary>
        /// Get a list of tasks
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public ICollection<Task> Tasks
        {
            get { return new ReadOnlyCollection<Task>(tasks); }
        }

        /// <summary>
        /// Gets the interval at which to run the tasks
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public int Interval
        {
            get { return Seconds * 1000; }
        }

        #endregion

        #region Methods

        private void Run()
        {
            if (Seconds <= 0)
                return;

            Started = DateTime.UtcNow;
            IsRunning = true;

            foreach (Task task in tasks)
            {
                task.Execute();
            }
            IsRunning = false;
        }

        private void TimerHandler(object state)
        {
            timer.Change(-1, -1);
            Run();
            timer.Change(Interval, Interval);
        }

        /// <summary>
        /// Inits a timer
        /// </summary>
        public void InitTimer()
        {
            if (timer == null)
            {
                timer = new Timer(TimerHandler, null, Interval, Interval);
            }
        }

        /// <summary>
        /// Adds a task to the thread
        /// </summary>
        /// <param name="task">The task to be added</param>
        public void AddTask(Task task)
        {
            if (!tasks.Contains(task))
            {
                tasks.Add(task);
            }
        }

        /// <summary>
        /// Disposes the instance
        /// </summary>
        public void Dispose()
        {
            if ((timer != null) && !disposed)
            {
                lock (this)
                {
                    timer.Dispose();
                    timer = null;
                    disposed = true;
                }
            }
        }

        #endregion
    }
}
