namespace Ns.Utility.Framework.Mvc
{
    public abstract class BaseEntityModel : BaseModel
    {
        public int Id { get; set; }
        public byte[] Version { get; set; }
    }
}