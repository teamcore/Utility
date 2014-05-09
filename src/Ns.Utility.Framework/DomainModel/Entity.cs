using System;
using System.Security.Principal;

namespace Ns.Utility.Framework.DomainModel
{
    [Serializable]
    public abstract class Entity : EntityWithTypedId<int>, IEntity
    {
        /// <summary>
        /// Gets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// Gets the deleted on.
        /// </summary>
        /// <value>
        /// The deleted on.
        /// </value>
        public DateTime? DeletedOn { get; private set; }

        /// <summary>
        /// Gets the deleted by.
        /// </summary>
        /// <value>
        /// The deleted by.
        /// </value>
        public string DeletedBy { get; private set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public byte[] RowVersion { get; private set; }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            IsDeleted = true;
            DeletedOn = DateTime.Now;
            DeletedBy = WindowsIdentity.GetCurrent().Name;
        }
    }
}
