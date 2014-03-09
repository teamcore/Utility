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

        internal User(string userName, string password, string firstName, string lastName, string accessKey)
        {
            PublicKey = SecurityHelper.GetPublicKey();
            PrivateKey = SecurityHelper.GetPrivateKey();
            UserName = userName;
            Password = SecurityHelper.Encrypt(password, PublicKey);
            FirstName = firstName;
            LastName = LastName;
            AccessKey = accessKey;
            settings = EngineContext.Current.Resolve<IConfigurationProvider<ApplicationSettings>>().Settings;
        }

        #endregion

        #region Properties

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DisplayName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string AccessKey { get; private set; }
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }
        public bool IsLoggedIn { get; private set; }
        public DateTime? LastLoginDate { get; private set; }
        public bool IsLockedOut { get; private set; }
        public DateTime? LastLockedDate { get; private set; }
        public int InvalidLoginAttemptCount { get; private set; }

        #endregion

        #region Method

        /// <summary>
        /// Authenticates the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="FunctionalException">User account is locked out.</exception>
        public bool Authenticate(string password)
        {
            bool result = false;
            var currentDate = DateTime.Now;

            if (IsLockedOut)
            {
                throw new FunctionalException("User account is locked out.");
            }

            var plainPassword = SecurityHelper.Decrypt(Password, PrivateKey);
            if (plainPassword == password)
            {
                AccessKey = Guid.NewGuid().ToString();
                LastLoginDate = currentDate;
                InvalidLoginAttemptCount = 0;
                result = true;
            }
            else
            {
                InvalidLoginAttemptCount++;

                if (InvalidLoginAttemptCount >= settings.MaxInvalidLoginAttemptCount)
                {
                    IsLockedOut = true;
                    LastLockedDate = currentDate;
                }
            }

            return result;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string password)
        {
            bool passwordChanged = false;
            var plainPassword = SecurityHelper.Decrypt(Password, PrivateKey);
            if (oldPassword == plainPassword)
            {
                Password = SecurityHelper.Encrypt(password, PublicKey);
                passwordChanged = true;
            }

            return passwordChanged;
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            IsLoggedIn = false;
            AccessKey = string.Empty;
        }

        #endregion
    }
}
