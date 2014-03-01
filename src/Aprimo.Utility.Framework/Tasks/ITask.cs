using System.Xml;

namespace Aprimo.Utility.Framework.Tasks 
{
    /// <summary>
    /// Interface that should be implemented by each task
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Execute task
        /// </summary>
        void Execute();
    }
}
