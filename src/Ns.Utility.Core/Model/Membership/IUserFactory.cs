namespace Ns.Utility.Core.Model.Membership
{
    public interface IUserFactory
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="loginId">The login id.</param>
        /// <param name="password">The password.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="accessKey">The access key.</param>
        /// <returns></returns>
        User CreateUser(string loginId, string password, string displayName, string accessKey);
    }
}