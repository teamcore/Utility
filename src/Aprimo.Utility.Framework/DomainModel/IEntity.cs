using System;

namespace Aprimo.Utility.Framework.DomainModel
{
    public interface IEntity : IEntityWithTypedId<int>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is published.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; }

        /// <summary>
        /// Gets the published on.
        /// </summary>
        /// <value>
        /// The published on.
        /// </value>
        DateTime? ActivatedOn { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        bool IsDeleted { get; }

        /// <summary>
        /// Gets the deleted on.
        /// </summary>
        /// <value>
        /// The deleted on.
        /// </value>
        DateTime? DeletedOn { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        byte[] Version { get; }
    }
}
