using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Models
{
    public class ProjectModel : BaseEntityModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }
    }
}