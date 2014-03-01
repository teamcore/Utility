using System;
using System.Linq;
using Aprimo.Utility.Framework.Data.Contract;
using Aprimo.Utility.Framework.Dependency;
using Aprimo.Utility.Framework.Tasks;
using Autofac;

namespace Aprimo.Utility.Framework
{
    public class WebEngine : IEngine
    {
        #region Fields

        private readonly IDependencyManager dependencyManager;
        private bool startupTaskStarted;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="WebEngine"/> class.
        /// </summary>
        public WebEngine()
            : this(new ContainerBuilder(), new DependencyManager())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebEngine"/> class.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        /// <param name="dependencyManager">The dependency manager.</param>
        public WebEngine(ContainerBuilder builder, IDependencyManager dependencyManager)
        {
            this.Builder = builder;
            Container = builder.Build();
            this.dependencyManager = dependencyManager;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the container.
        /// </summary>
        public IContainer Container { get; protected set; }
        public ContainerBuilder Builder { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize components and plugins in the Aprimo.Utility.Framework environment.
        /// </summary>
        /// <param name="databaseIsConfigured">if set to <c>true</c> [database is configured].</param>
        public void Initialize(bool databaseIsConfigured)
        {
            dependencyManager.Register(Builder);

            InitializeTaskTypes();
            RunStartupTasks();

            if (startupTaskStarted)
            {
                StartScheduledTasks();
            }
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            ResetStartupTasks();
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Runs the startup tasks.
        /// </summary>
        private void RunStartupTasks()
        {
            var typeFinder = Container.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks = startUpTaskTypes.Select(startUpTaskType => (IStartupTask)Activator.CreateInstance(startUpTaskType)).ToList();
            startUpTasks = startUpTasks.AsQueryable().OrderBy(st => st.Order).ToList();
            foreach (var startUpTask in startUpTasks)
            {
                startUpTask.Execute();
            }

            startupTaskStarted = true;
        }

        private void ResetStartupTasks()
        {
            var typeFinder = Container.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks = startUpTaskTypes.Select(startUpTaskType => (IStartupTask)Activator.CreateInstance(startUpTaskType)).ToList();
            startUpTasks = startUpTasks.AsQueryable().OrderByDescending(st => st.Order).ToList();
            foreach (var startUpTask in startUpTasks)
            {
                startUpTask.Reset();
            }

            startupTaskStarted = false;
        }

        private void InitializeTaskTypes()
        {
            var commitRequired = false;
            var repository = EngineContext.Current.Container.Resolve<IRepository<TaskType>>();
            var unitOfWork = EngineContext.Current.Container.Resolve<IUnitOfWork>();

            var typeFinder = Container.Resolve<ITypeFinder>();
            var tasks = typeFinder.FindClassesOfType<ITask>();

            foreach (var task in tasks)
            {
                string name = task.Name;
                var taskType = repository.Find(x => x.Name == name).FirstOrDefault();
                if (taskType == null)
                {
                    taskType = new TaskType(task.Name, task.AssemblyQualifiedName);
                    repository.Add(taskType);
                    commitRequired = true;
                }
            }

            if (commitRequired)
            {
                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// Starts the scheduled tasks.
        /// </summary>
        private void StartScheduledTasks()
        {
            TaskManager.Instance.Initialize();
            TaskManager.Instance.Start();
        }

        #endregion

    }
}
