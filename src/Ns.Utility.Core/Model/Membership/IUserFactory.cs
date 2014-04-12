namespace Ns.Utility.Core.Model.Membership
{
    public interface IUserFactory
    {
        User CreateUser(string domain, string userName, string firstName, string lastName);

        User CreateUser(string domain, string userName);
    }
}