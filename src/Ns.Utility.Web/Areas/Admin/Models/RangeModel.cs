using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Areas.Admin.Models
{
    public class RangeModel : BaseEntityModel
    {
        public RangeModel()
        {
            Projects = new List<ProjectModel>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }



        [Required]
        [Range(0, int.MaxValue)]
        public int Min { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Max { get; set; }
        public int Next { get; set; }

        [Required]
        [Display(Name = "Project")]
        [Range(0, int.MaxValue)]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectModel> Projects { get; private set; }
    }
}