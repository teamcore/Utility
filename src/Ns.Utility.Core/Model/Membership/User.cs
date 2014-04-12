using System;
using Ns.Utility.Framework;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Exceptions;
using Ns.Utility.Framework.Security;
using Ns.Utility.Framework.Settings;

namespace Ns.Utility.Core.Model.Membership
{
    [DomainSignature]
    public class User : Entity
    {
        #region Fields

        private readonly ApplicationSettings settings;

        #endregion

        #region ctor

        protected User()
        {

        }

        internal User(string domain, string userName) : this(domain, userName, string.Empty, string.Empty)
        {
            
        }

        internal User(string domain, string userName, string firstName, string lastName)
        {
            Domain = domain;
            UserName = userName;
            FirstName = firstName;
            LastName = LastName;
            settings = EngineContext.Current.Resolve<IConfigurationProvider<ApplicationSettings>>().Settings;
        }

        #endregion

        #region Properties

        public string Domain { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DisplayName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public bool IsAdmin { get; private set; }
        public bool IsLoggedIn { get; private set; }
        public DateTime? LastLoginDate { get; private set; }
        
        #endregion

        #region Method

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            IsLoggedIn = false;
        }

        #endregion
    }
}
