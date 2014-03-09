namespace Ns.Utility.Core.Model.Membership
{
    public class UserFactory : IUserFactory
    {
        #region IUserFactory Members

        public User CreateUser(string userName, string password, string firstName, string lastName, string accessKey)
        {
            return new User(userName, password, firstName, lastName, accessKey);
        }

        #endregion
    }
}
