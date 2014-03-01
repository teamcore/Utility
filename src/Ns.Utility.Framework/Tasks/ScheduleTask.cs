using System;
using Ns.Utility.Framework.DomainModel;

namespace Ns.Utility.Framework.Tasks
{
    public class ScheduleTask : Entity
    {
        #region Fields


        #endregion

        #region ctor

        protected ScheduleTask()
        {

        }

        public ScheduleTask(string name, TaskType taskType)
            : this(name, taskType, 60, true, false)
        {

        }

        public ScheduleTask(string name, TaskType taskType, int seconds, bool enabled, bool stopOnError)
        {
            Name = name;
            TaskType = taskType;
            Seconds = seconds;
            Enabled = enabled;
            StopOnError = stopOnError;
        }

        public ScheduleTask(string name, long taskTypeId)
            : this(name, taskTypeId, 60, true, false)
        {

        }

        public ScheduleTask(string name, long taskTypeId, int seconds, bool enabled, bool stopOnError)
        {
            Name = name;
            TaskTypeId = taskTypeId;
            Seconds = seconds;
            Enabled = enabled;
            StopOnError = stopOnError;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get; set; }

        /// <summary>
        /// Gets or sets the type of appropriate ITask class
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public TaskType TaskType { get; protected set; }

        /// <summary>
        /// Gets or sets the task type id.
        /// </summary>
        /// <value>
        /// The type id.
        /// </value>
        public long TaskTypeId { get; protected set; }

        /// <summary>
        /// Gets or sets the value indicating whether a task is enabled
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; protected set; }

        /// <summary>
        /// Gets or sets the value indicating whether a task should be stopped on some error
        /// </summary>
        /// <value>
        ///   <c>true</c> if [stop on error]; otherwise, <c>false</c>.
        /// </value>
        public bool StopOnError { get; protected set; }

        /// <summary>
        /// Gets or sets the last start UTC.
        /// </summary>
        /// <value>
        /// The last start UTC.
        /// </value>
        public DateTime? LastStartUtc { get; protected set; }

        /// <summary>
        /// Gets or sets the last end UTC.
        /// </summary>
        /// <value>
        /// The last end UTC.
        /// </value>
        public DateTime? LastEndUtc { get; protected set; }

        /// <summary>
        /// Gets or sets the last success UTC.
        /// </summary>
        /// <value>
        /// The last success UTC.
        /// </value>
        public DateTime? LastSuccessUtc { get; protected set; }

        #endregion

        #region Methods

        public void Enable()
        {
            if (!Enabled)
            {
                Enabled = true;
            }
        }

        public void Disable()
        {
            if (Enabled)
            {
                Enabled = false;
            }
        }

        public void Started()
        {
            LastStartUtc = DateTime.UtcNow;
        }


        public void Completed()
        {
            LastEndUtc = LastSuccessUtc = DateTime.UtcNow;
        }

        public void CompleteWithError(Exception exception = null)
        {
            Enabled = !StopOnError;
            LastEndUtc = DateTime.UtcNow;
        }
        #endregion
    }
}
