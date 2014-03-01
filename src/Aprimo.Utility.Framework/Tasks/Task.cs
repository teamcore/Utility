using System;
using System.Diagnostics;
using Aprimo.Utility.Framework.Data;
using Aprimo.Utility.Framework.Data.Contract;
using Aprimo.Utility.Framework.Logger;

namespace Aprimo.Utility.Framework.Tasks 
{
    /// <summary>
    /// Task
    /// </summary>
    public class Task
    {
        private readonly ScheduleTask scheduleTask;
        private readonly string type;
        
        private bool isRunning;

        /// <summary>
        /// Ctor for Task
        /// </summary>
        /// <param name="task">Task </param>
        public Task(ScheduleTask task)
        {
            scheduleTask = task;
            type = task.TaskType.AssemblyQualifiedName;
        }

        private ITask CreateTask()
        {
            ITask task = null;
            if (Enabled)
            {
                var type2 = System.Type.GetType(type);
                if (type2 != null)
                {
                    task = Activator.CreateInstance(type2) as ITask;
                }
                //enabled = task != null;
            }
            return task;
        }

        /// <summary>
        /// Executes the task
        /// </summary>
        public void Execute()
        {
            isRunning = true;

            try
            {
                var task = CreateTask();
                if (task != null)
                {
                    scheduleTask.Started();
                    task.Execute();
                    scheduleTask.Completed();
                }
            }
            catch (Exception exc)
            {
                scheduleTask.CompleteWithError();

                //log error
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.InsertLog(LogLevel.Error, exc.Message, exc.StackTrace);
                Debug.WriteLine("Error saving schedule task datetimes. Exception: {0}", exc);
            }

            try
            {
                var repository = EngineContext.Current.Resolve<IRepository<ScheduleTask>>();
                var unitOfWork = EngineContext.Current.Resolve<IUnitOfWork>();
                repository.Update(scheduleTask);
                unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.InsertLog(LogLevel.Error, exception.Message, exception.StackTrace);
                Debug.WriteLine("Error saving schedule task datetimes. Exception: {0}", exception);
            }

            isRunning = false;
        }

        /// <summary>
        /// A value indicating whether a task is running
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
        }

        /// <summary>
        /// Datetime of the last start
        /// </summary>
        public DateTime? LastStartUtc
        {
            get
            {
                return scheduleTask.LastStartUtc;
            }
        }

        /// <summary>
        /// Datetime of the last end
        /// </summary>
        public DateTime? LastEndUtc
        {
            get
            {
                return scheduleTask.LastEndUtc;
            }
        }

        /// <summary>
        /// Datetime of the last success
        /// </summary>
        public DateTime? LastSuccessUtc
        {
            get
            {
                return scheduleTask.LastSuccessUtc;
            }
        }

        /// <summary>
        /// A value indicating type of the task
        /// </summary>
        public string TaskType
        {
            get
            {
                return scheduleTask.TaskType.AssemblyQualifiedName;
            }
        }

        /// <summary>
        /// A value indicating whether to stop task on error
        /// </summary>
        public bool StopOnError
        {
            get
            {
                return scheduleTask.StopOnError;
            }
        }

        /// <summary>
        /// Get the task name
        /// </summary>
        public string Name
        {
            get
            {
                return scheduleTask.Name;
            }
        }

        /// <summary>
        /// A value indicating whether the task is enabled
        /// </summary>
        public bool Enabled
        {
            get
            {
                return scheduleTask.Enabled;
            }
        }
    }
}
