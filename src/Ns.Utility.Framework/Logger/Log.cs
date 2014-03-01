using System;
using Ns.Utility.Framework.DomainModel;

namespace Ns.Utility.Framework.Logger
{
    /// <summary>
    /// Represents a log record
    /// </summary>
    public class Log : Entity
    {
        /// <summary>
        /// Gets or sets the log level identifier
        /// </summary>
        /// <value>
        /// The log level id.
        /// </value>
        public int LogLevelId { get; set; }

        /// <summary>
        /// Gets or sets the short message
        /// </summary>
        /// <value>
        /// The short message.
        /// </value>
        public string ShortMessage { get; set; }

        /// <summary>
        /// Gets or sets the full exception
        /// </summary>
        /// <value>
        /// The full message.
        /// </value>
        public string FullMessage { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        /// <value>
        /// The customer id.
        /// </value>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the page URL
        /// </summary>
        /// <value>
        /// The page URL.
        /// </value>
        public string PageUrl { get; set; }

        /// <summary>
        /// Gets or sets the referrer URL
        /// </summary>
        /// <value>
        /// The referrer URL.
        /// </value>
        public string ReferrerUrl { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        /// <value>
        /// The created on UTC.
        /// </value>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the log level
        /// </summary>
        /// <value>
        /// The log level.
        /// </value>
        public LogLevel LogLevel
        {
            get
            {
                return (LogLevel)LogLevelId;
            }
            set
            {
                LogLevelId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        public int? UserId { get; set; }
    }
}
