using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ns.Utility.Framework.DomainModel.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        int Id { get; set; }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid();

        /// <summary>
        /// Validations the results.
        /// </summary>
        /// <returns></returns>
        ICollection<ValidationResult> ValidationResults();
    }
}