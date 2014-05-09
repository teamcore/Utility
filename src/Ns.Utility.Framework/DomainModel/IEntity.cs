using System;

namespace Ns.Utility.Framework.DomainModel
{
    public interface IEntity : IEntityWithTypedId<int>
    {
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
        /// Gets the deleted by.
        /// </summary>
        /// <value>
        /// The deleted by.
        /// </value>
        string DeletedBy { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        byte[] RowVersion { get; }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete();
    }
}
