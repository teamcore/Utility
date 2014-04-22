using Ns.Utility.Framework.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ns.Utility.Web.Areas.Admin.Models
{
    public class ProjectModel : BaseEntityModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }

        public bool HasRange { get; set; }
    }
}