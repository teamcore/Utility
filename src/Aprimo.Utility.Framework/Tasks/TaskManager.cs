using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Aprimo.Utility.Framework.Tasks
{
    /// <summary>
    /// Represents task manager
    /// </summary>
    public class TaskManager
    {
        private static readonly TaskManager taskManager = new TaskManager();
        private readonly List<TaskThread> taskThreads = new List<TaskThread>();

        private TaskManager()
        {
        }

        /// <summary>
        /// Initializes the task manager with the property values specified in the configuration file.
        /// </summary>
        public void Initialize()
        {
            taskThreads.Clear();
            var repository = EngineContext.Current.Resolve<IScheduleTaskService>();
            var scheduleTasks = repository.GetAllTasks().OrderBy(x => x.Seconds);

            foreach (var scheduleTaskGrouped in scheduleTasks.GroupBy(x => x.Seconds))
            {
                var taskThread = new TaskThread();
                taskThread.Seconds = scheduleTaskGrouped.Key;
                this.taskThreads.Add(taskThread);
                foreach (var scheduleTask in scheduleTaskGrouped)
                {
                    var task = new Task(scheduleTask);
                    taskThread.AddTask(task);
                }
            }

        }

        /// <summary>
        /// Starts the task manager
        /// </summary>
        public void Start()
        {
            foreach (var taskThread in taskThreads)
            {
                taskThread.InitTimer();
            }
        }

        /// <summary>
        /// Stops the task manager
        /// </summary>
        public void Stop()
        {
            foreach (var taskThread in taskThreads)
            {
                taskThread.Dispose();
            }
        }

        /// <summary>
        /// Gets the task mamanger instance
        /// </summary>
        public static TaskManager Instance
        {
            get
            {
                return taskManager;
            }
        }

        /// <summary>
        /// Gets a list of task threads of this task manager
        /// </summary>
        public IList<TaskThread> TaskThreads
        {
            get
            {
                return new ReadOnlyCollection<TaskThread>(taskThreads);
            }
        }
    }
}
