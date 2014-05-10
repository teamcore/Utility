using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Areas.Deployment.Models
{
    public class BuildViewModel : BaseEntityModel
    {
        public BuildViewModel()
        {
            Projects = new List<ProjectModel>();
            Packages = new Collection<HttpPostedFileBase>();
            Scripts = new Collection<HttpPostedFileBase>();
        }

        [Display(Name = "Build Name"), Required]
        public string Name { get; set; }

        [Display(Name = "Change Set"), Required]
        public string ChangeSet { get; set; }

        [Display(Name = "Release"), Required]
        public string Release { get; set; }

        [Display(Name = "Project"), Required]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectModel> Projects { get; set; }
        public IEnumerable<HttpPostedFileBase> Packages { get; set; }
        public IEnumerable<HttpPostedFileBase> Scripts { get; set; }
    }
}