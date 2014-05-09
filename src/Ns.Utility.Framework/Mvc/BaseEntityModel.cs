using System.ComponentModel.DataAnnotations;
namespace Ns.Utility.Framework.Mvc
{
    public abstract class BaseEntityModel : BaseModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }

        public bool IsNew { get { return Id == 0; } }
    }
}