using System;
using System.Runtime.Caching;

namespace Ns.Utility.Framework.Caching
{
    public class TypeChangeMonitor : ChangeMonitor
    {

        private readonly string uniqueId;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeChangeMonitor" /> class.
        /// </summary>
        public TypeChangeMonitor()
        {
            uniqueId = string.Format("{0}-{1}", GetType().Name, Guid.NewGuid());

            InitializationComplete();
        }

        /// <summary>
        /// Releases all managed and unmanaged resources and any references to the <see cref="T:System.Runtime.Caching.ChangeMonitor" /> instance. This overload must be implemented by derived change-monitor classes.
        /// </summary>
        /// <param name="disposing">true to release managed and unmanaged resources and any references to a <see cref="T:System.Runtime.Caching.ChangeMonitor" /> instance; false to release only unmanaged resources. When false is passed, the <see cref="M:System.Runtime.Caching.ChangeMonitor.Dispose(System.Boolean)" /> method is called by a finalizer thread and any external managed references are likely no longer valid because they have already been garbage collected.</param>
        protected override void Dispose(bool disposing)
        {
            Dispose();
        }

        /// <summary>
        /// Gets a value that represents the <see cref="T:System.Runtime.Caching.ChangeMonitor" /> class instance.
        /// </summary>
        /// <returns>The identifier for a change-monitor instance.</returns>
        public override string UniqueId
        {
            get { return uniqueId; }
        }

        /// <summary>
        /// Called when [invalidate cache element].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public void OnInvalidateCacheElement(object sender, EventArgs args)
        {
            OnChanged(null);
        }

    }
}