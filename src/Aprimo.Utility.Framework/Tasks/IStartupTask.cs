namespace Aprimo.Utility.Framework.Tasks 
{
    public interface IStartupTask 
    {
        /// <summary>
        /// Executes this instance.
        /// </summary>
        void Execute();

        /// <summary>
        /// Resets this instance.
        /// </summary>
        void Reset();

        /// <summary>
        /// Gets the order.
        /// </summary>
        int Order { get; }
    }
}
