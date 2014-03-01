using System;

namespace Ns.Utility.Framework.DomainModel
{
    [Serializable]
    public abstract class Entity : EntityWithTypedId<int>, IEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// {D255958A-8513-4226-94B9-080D98F904A1}  <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the activated on.
        /// </summary>
        /// <value>
        /// The activated on.
        /// </value>
        public DateTime? ActivatedOn { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets the deleted on.
        /// </summary>
        /// <value>
        /// The deleted on.
        /// </value>
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public byte[] Version { get; set; }
    }
}
