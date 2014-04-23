using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Areas.Admin.Models;
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
        public TermModel()
        {
            Key = "Next ID";
            Projects = new List<ProjectModel>();
        }

        [Display(Name = "Term ID")]
        public string Key { get; set; }

        [Required]
        [Display(Name = "Term Text")]
        public string Text { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectModel> Projects { get; private set; }
    }
}