namespace Ns.Utility.Core.Model.Membership
{
    public interface IUserFactory
    {
        User CreateUser(string userName, string password, string firstName, string lastName, string accessKey);
    }
}