using System;
using System.Runtime.Serialization;
using System.Security;

namespace Ns.Utility.Framework.Exceptions
{
    [Serializable]
    public class FunctionalException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalException"/> class.
        /// </summary>
        public FunctionalException()
            : this("Functional error occour.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FunctionalException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public FunctionalException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        [SecuritySafeCritical]
        protected FunctionalException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
