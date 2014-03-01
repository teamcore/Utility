using System;
using System.Runtime.Serialization;
using System.Security;

namespace Ns.Utility.Framework.Exceptions
{
    [Serializable]
    public class RsaCryptoException : TechnicalException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RsaCryptoException"/> class.
        /// </summary>
        public RsaCryptoException()
            : this("Technical error occour while encrypting or decrypting data.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaCryptoException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public RsaCryptoException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaCryptoException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RsaCryptoException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsaCryptoException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        [SecuritySafeCritical]
        protected RsaCryptoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
