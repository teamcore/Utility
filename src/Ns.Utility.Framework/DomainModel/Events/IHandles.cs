namespace Ns.Utility.Framework.DomainModel.Events
{
    public interface IHandles<in T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
