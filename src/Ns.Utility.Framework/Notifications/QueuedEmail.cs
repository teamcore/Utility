using System;
using System.Net.Mail;
using Ns.Utility.Framework.DomainModel;

namespace Ns.Utility.Framework.Notifications
{
    public class QueuedEmail : Entity
    {
        protected QueuedEmail()
        {

        }

        public QueuedEmail(string from, string to, string cc, string bcc, string subject, string body)
            : this(from, string.Empty, to, string.Empty, cc, string.Empty, bcc, string.Empty, subject, body, MailPriority.Normal)
        {
            
        }

        public QueuedEmail(string from, string fromName, string to, string toName, string cc, string ccName, string bcc, string bccName, string subject, string body, MailPriority priority)
        {
            From = from;
            FromName = fromName;
            To = to;
            ToName = toName;
            Cc = cc;
            CcName = ccName;
            Bcc = bcc;
            BccName = bccName;
            Subject = subject;
            Body = body;
            Priority = priority;
        }

        public string From { get; private set; }
        public string FromName { get; private set; }
        public string To { get; private set; }
        public string ToName { get; private set; }
        public string Cc { get; private set; }
        public string CcName { get; private set; }
        public string Bcc { get; private set; }
        public string BccName { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public MailPriority Priority { get; private set; }
        public int SentTries { get; private set; }
        public DateTime? SentOn { get; private set; }
    }
}
