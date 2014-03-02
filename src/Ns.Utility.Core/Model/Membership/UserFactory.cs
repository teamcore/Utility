namespace Ns.Utility.Core.Model.Membership
{
    public class UserFactory : IUserFactory
    {
        #region IUserFactory Members

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="loginId">The login id.</param>
        /// <param name="password">The password.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="accessKey">The access key.</param>
        /// <returns></returns>
        public User CreateUser(string loginId, string password, string displayName, string accessKey)
        {
            return new User(loginId, password, displayName, accessKey);
        }

        #endregion
    }
}
