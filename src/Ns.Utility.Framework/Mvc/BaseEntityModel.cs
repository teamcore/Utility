namespace Ns.Utility.Framework.Mvc
{
    public abstract class BaseEntityModel : BaseModel
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public bool IsLocked { get; set; }
        public byte[] Version { get; set; }
    }
}