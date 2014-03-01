namespace Ns.Utility.Framework.DomainModel.Commands
{
    public interface IDomainRightCommand
    {
        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>
        /// The name of the module.
        /// </value>
        string ModuleName { get; }

        /// <summary>
        /// Gets the display name of the command.
        /// </summary>
        /// <value>
        /// The display name of the command.
        /// </value>
        string CommandDisplayName { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IDomainRightCommand"/> is ignore.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ignore; otherwise, <c>false</c>.
        /// </value>
        bool Ignore { get; }
    }
}
