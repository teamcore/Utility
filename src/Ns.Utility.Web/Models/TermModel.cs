using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Models
{
    public class TermModel : BaseEntityModel
    {
        [Display(Name = "Resource ID")]
        public int? Key { get; set; }

        [Required]
        [Display(Name = "Term")]
        public string Text { get; set; }
        public string Description { get; set; }
    }
}