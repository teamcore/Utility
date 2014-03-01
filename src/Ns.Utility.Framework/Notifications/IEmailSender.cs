using System.Collections.Generic;
using System.Net.Mail;

namespace Ns.Utility.Framework.Notifications
{
    public interface IEmailSender
    {
        void Send(string emailId, QueuedEmail email);
        void Send(string emailId, string subject, string body, MailAddress to, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal);
        void Send(string emailId, string subject, string body, string toAddress, string toName, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal);
        void Send(EmailAccount emailAccount, QueuedEmail email);
        void Send(EmailAccount emailAccount, string subject, string body, string toAddress, string toName, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal);
        void Send(EmailAccount emailAccount, string subject, string body, MailAddress to, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal);
    }
}
