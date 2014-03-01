namespace Ns.Utility.Framework.DomainModel.Commands
{
    public abstract class MenuCommandBase : CommandBase, IMenuCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuCommandBase"/> class.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="menuName">Name of the menu.</param>
        /// <param name="commandDisplayName">Display name of the command.</param>
        protected MenuCommandBase(string moduleName, string menuName, string commandDisplayName)
            : this(moduleName, menuName, commandDisplayName, false)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuCommandBase"/> class.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="menuName">Name of the menu.</param>
        /// <param name="commandDisplayName">Display name of the command.</param>
        /// <param name="ignoreCommand">if set to <c>true</c> [ignore].</param>
        protected MenuCommandBase(string moduleName, string menuName, string commandDisplayName, bool ignoreCommand)
            : base(moduleName, commandDisplayName, ignoreCommand)
        {
            MenuName = menuName;
        }

        /// <summary>
        /// Gets or sets the name of the menu.
        /// </summary>
        /// <value>
        /// The name of the menu.
        /// </value>
        public string MenuName { get; protected set; }
    }
}
