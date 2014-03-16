using Ns.Utility.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Ranges
{
    public class RangeExhaustedException : FunctionalException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeExhaustedException"/> class.
        /// </summary>
        public RangeExhaustedException()
            : this("Id range exhausted, renew with next id range.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeExhaustedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public RangeExhaustedException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeExhaustedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RangeExhaustedException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeExhaustedException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        [SecuritySafeCritical]
        protected RangeExhaustedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
