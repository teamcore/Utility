using Ns.Utility.Framework.DomainModel;

namespace Ns.Utility.Framework.Notifications
{
    public class EmailAccount : Entity
    {
        protected EmailAccount()
        {

        }

        public EmailAccount(string name, string email, string smtpHost, int smtpPort, string popHost, int popPort, string userName, string password)
            : this(name, email, string.Empty, smtpHost, smtpPort, popHost, popPort, userName, password, true, true, true)
        {
            
        }

        public EmailAccount(string name, string email, string dispalyName, string smtpHost, int smtpPort, string popHost, int popPort, string userName, string password, bool smtpSslEnabled, bool pop3SslEnabled, bool useDefaultCredentials)
        {
            Name = name;
            Email = email;
            DisplayName = dispalyName;
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            PopHost = popHost;
            PopPort = popPort;
            UserName = userName;
            Password = password;
            SmtpSslEnabled = smtpSslEnabled;
            Pop3SslEnabled = pop3SslEnabled;
            UseDefaultCredentials = useDefaultCredentials;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }
        public string SmtpHost { get; private set; }
        public int SmtpPort { get; private set; }
        public string PopHost { get; private set; }
        public int PopPort { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool SmtpSslEnabled { get; private set; }
        public bool Pop3SslEnabled { get; private set; }
        public bool UseDefaultCredentials { get; private set; }
        public string FriendlyName
        {
            get { return string.IsNullOrWhiteSpace(DisplayName) ? Email : string.Format("{0} ({1})", Email, DisplayName); }
        }
    }
}
