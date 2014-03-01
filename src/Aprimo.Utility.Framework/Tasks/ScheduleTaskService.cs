using System;
using System.Collections.Generic;
using System.Linq;
using Aprimo.Utility.Framework.Data;
using Aprimo.Utility.Framework.Data.Contract;

namespace Aprimo.Utility.Framework.Tasks
{
    /// <summary>
    /// Task service
    /// </summary>
    public class ScheduleTaskService : IScheduleTaskService
    {
        #region Fields

        private readonly IRepository<ScheduleTask> taskRepository;

        #endregion

        #region Ctor

        public ScheduleTaskService(IRepository<ScheduleTask> taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a task
        /// </summary>
        /// <param name="task">Task</param>
        public virtual void DeleteTask(ScheduleTask task)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            taskRepository.Delete(task.Id);
        }

        /// <summary>
        /// Gets a task
        /// </summary>
        /// <param name="taskId">Task identifier</param>
        /// <returns>Task</returns>
        public virtual ScheduleTask GetTaskById(int taskId)
        {
            if (taskId == 0)
                return null;

            return taskRepository.FindOne(x => x.Id == taskId);
        }

        /// <summary>
        /// Gets a task by its type
        /// </summary>
        /// <param name="taskType">Task type</param>
        /// <returns>Task</returns>
        public virtual ScheduleTask GetTaskByType(string taskType)
        {
            if (String.IsNullOrWhiteSpace(taskType))
                return null;

            var query = taskRepository.AsQueryable();
            query = query.Where(st => st.TaskType.AssemblyQualifiedName == taskType);
            query = query.OrderByDescending(t => t.Id);

            var task = query.FirstOrDefault();
            return task;
        }

        /// <summary>
        /// Gets all tasks
        /// </summary>
        /// <returns>Tasks</returns>
        public virtual IList<ScheduleTask> GetAllTasks()
        {
            var query = taskRepository.AsQueryable();
            ////query = query.OrderByDescending(t => t.Seconds);

            var tasks = query.ToList();
            return tasks;
        }

        /// <summary>
        /// Inserts a task
        /// </summary>
        /// <param name="task">Task</param>
        public virtual void InsertTask(ScheduleTask task)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            taskRepository.Add(task);
        }

        /// <summary>
        /// Updates the task
        /// </summary>
        /// <param name="task">Task</param>
        public virtual void UpdateTask(ScheduleTask task)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            taskRepository.Update(task);
        }

        #endregion
    }
}
