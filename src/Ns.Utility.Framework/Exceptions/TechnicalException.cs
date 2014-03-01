using System;
using System.Runtime.Serialization;
using System.Security;

namespace Ns.Utility.Framework.Exceptions
{
    [Serializable]
    public class TechnicalException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalException"/> class.
        /// </summary>
        public TechnicalException()
            : this("Technical error occour.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public TechnicalException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public TechnicalException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TechnicalException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        [SecuritySafeCritical]
        protected TechnicalException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
