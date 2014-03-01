using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Aprimo.Utility.Framework.Data.Contract;
using Aprimo.Utility.Framework.Exceptions;

namespace Aprimo.Utility.Framework.Notifications
{
    public class EmailSender : IEmailSender
    {
        private readonly IRepository<EmailAccount> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSender"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public EmailSender(IRepository<EmailAccount> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Sends the specified email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="FunctionalException"></exception>
        public virtual void Send(string emailId, QueuedEmail email)
        {
            var emailAccount = repository.FindOne(x => x.Email == emailId && x.IsDeleted == false);
            if (emailAccount == null)
            {
                throw new FunctionalException(string.Format("Email account does not exists with email id: '{0}'", emailId));
            }

            Send(emailAccount, email);
        }

        /// <summary>
        /// Sends the specified email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="bcc">The BCC.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="priority">The priority.</param>
        /// <exception cref="FunctionalException"></exception>
        public virtual void Send(string emailId, string subject, string body, MailAddress to, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal)
        {
            var emailAccount = repository.FindOne(x => x.Email == emailId && x.IsDeleted == false);
            if (emailAccount == null)
            {
                throw new FunctionalException(string.Format("Email account does not exists with email id: '{0}'", emailId));
            }

            Send(emailAccount, subject, body, to, bcc, cc, priority);
        }

        /// <summary>
        /// Sends the specified email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <param name="?">The ?.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="fromAddress">From address.</param>
        /// <param name="fromName">From name.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="toName">To name.</param>
        /// <param name="bcc">The BCC.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="priority">The priority.</param>
        public virtual void Send(string emailId, string subject, string body, string toAddress, string toName, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal)
        {
            var emailAccount = repository.FindOne(x => x.Email == emailId && x.IsDeleted == false);
            if (emailAccount == null)
            {
                throw new FunctionalException(string.Format("Email account does not exists with email id: '{0}'", emailId));
            }

            Send(emailAccount, subject, body, toAddress, toName, bcc, cc, priority);
        }

        /// <summary>
        /// Sends the specified email account.
        /// </summary>
        /// <param name="emailAccount">The email account.</param>
        /// <param name="email">The email.</param>
        public virtual void Send(EmailAccount emailAccount, QueuedEmail email)
        {
            Send(emailAccount, email.Subject, email.Body, email.To, email.ToName, new string[] { email.Bcc }, new string[] { email.Cc }, email.Priority);
        }

        /// <summary>
        /// Sends the specified email account.
        /// </summary>
        /// <param name="emailAccount">The email account.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="fromAddress">From address.</param>
        /// <param name="fromName">From name.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="toName">To name.</param>
        /// <param name="bcc">The BCC.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="priority">The priority.</param>
        public virtual void Send(EmailAccount emailAccount, string subject, string body, string toAddress, string toName, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal)
        {
            Send(emailAccount, subject, body, new MailAddress(toAddress, toName), bcc, cc, priority);
        }

        /// <summary>
        /// Sends the specified email account.
        /// </summary>
        /// <param name="emailAccount">The email account.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="bcc">The BCC.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="priority">The priority.</param>
        public virtual void Send(EmailAccount emailAccount, string subject, string body, MailAddress to, IEnumerable<string> bcc = null, IEnumerable<string> cc = null, MailPriority priority = MailPriority.Normal)
        {
            var message = new MailMessage();
            message.From = new MailAddress(emailAccount.Email, emailAccount.DisplayName);
            message.To.Add(to);
            
            if (null != bcc)
            {
                foreach (var address in bcc.Where(bccValue => !String.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(address.Trim());
                }
            }

            if (null != cc)
            {
                foreach (var address in cc.Where(ccValue => !String.IsNullOrWhiteSpace(ccValue)))
                {
                    message.CC.Add(address.Trim());
                }
            }

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.Priority = priority;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = emailAccount.UseDefaultCredentials;
                smtpClient.Host = emailAccount.SmtpHost;
                smtpClient.Port = emailAccount.SmtpPort;
                smtpClient.EnableSsl = emailAccount.SmtpSslEnabled;
                smtpClient.Credentials = emailAccount.UseDefaultCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(emailAccount.UserName, emailAccount.Password);
                smtpClient.Send(message);
            }
        }
    }
}
