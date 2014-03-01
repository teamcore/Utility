using Ns.Utility.Framework.DomainModel;

namespace Ns.Utility.Framework.Tasks
{
    public class TaskType : Entity
    {
        protected TaskType()
        {
            
        }

        public TaskType(string name, string assemblyQualifiedName)
        {
            Name = name;
            AssemblyQualifiedName = assemblyQualifiedName;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the assembly qualified.
        /// </summary>
        /// <value>
        /// The name of the assembly qualified.
        /// </value>
        public string AssemblyQualifiedName { get; protected set; }
    }
}
