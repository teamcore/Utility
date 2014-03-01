using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ns.Utility.Framework.DomainModel.Commands
{
    [Serializable]
    public abstract class CommandBase : ICommand, IDomainRightCommand
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase"/> class.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="commandDisplayName">Display name of the command.</param>
        protected CommandBase(string moduleName, string commandDisplayName) : this(moduleName, commandDisplayName, false)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase"/> class.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="commandDisplayName">Display name of the command.</param>
        /// <param name="ignore">if set to <c>true</c> [ignore].</param>
        protected CommandBase(string moduleName, string commandDisplayName, bool ignore)
        {
            ModuleName = moduleName;
            CommandDisplayName = commandDisplayName;
            Ignore = ignore;
        }

        #endregion

        #region ICommand Member

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsValid()
        {
            return ValidationResults().Count == 0;
        }

        /// <summary>
        /// Validations the results.
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<ValidationResult> ValidationResults()
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this, null, null), validationResults, true);
            return validationResults;
        }

        #endregion

        #region IDomainRightCommand Member

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>
        /// The name of the module.
        /// </value>
        public string ModuleName { get; protected set; }

        /// <summary>
        /// Gets the display name of the command.
        /// </summary>
        /// <value>
        /// The display name of the command.
        /// </value>
        public string CommandDisplayName { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IDomainRightCommand"/> is ignore.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ignore; otherwise, <c>false</c>.
        /// </value>
        public bool Ignore { get; protected set; }

        #endregion
    }
}