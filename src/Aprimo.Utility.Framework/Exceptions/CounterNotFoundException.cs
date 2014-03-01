using System;

namespace Aprimo.Utility.Framework.Exceptions
{
    [Serializable]
    public class CounterNotFoundException : TechnicalException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CounterNotFoundException"/> class.
        /// </summary>
        public CounterNotFoundException()
            : base("Counter not configured.")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CounterNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CounterNotFoundException(string message)
            : base(message)
        {

        }

        public CounterNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {}
    }
}
