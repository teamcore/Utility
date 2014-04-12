namespace Ns.Utility.Core.Model.Membership
{
    public class UserFactory : IUserFactory
    {
        #region IUserFactory Members

        public User CreateUser(string domain, string userName, string firstName, string lastName)
        {
            return new User(domain, userName, firstName, lastName);
        }

        public User CreateUser(string domain, string userName)
        {
            return new User(domain, userName);
        }

        #endregion
    }
}
