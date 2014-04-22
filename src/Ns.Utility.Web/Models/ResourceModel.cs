using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Models
{
    public class ResourceModel : BaseEntityModel
    {
        public ResourceModel()
        {
            Key = "Next ID";
            Projects = new List<ProjectModel>();
        }

        [Display(Name = "Resource ID")]
        public string Key { get; set; }

        [Required]
        [Display(Name = "Resource Text")]
        public string Text { get; set; }
        public string Description { get; set; }

        [Required]
        [Display(Name = "Project")]
        [Range(0, int.MaxValue)]
        public int ProjectId { get; set; }
        public List<ProjectModel> Projects { get; private set; }
    }
}