using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public string Name { get; set; }
        public string ChangeSet { get; set; }
        public string Release { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectModel> Projects { get; set; }
        public IEnumerable<HttpPostedFileBase> Packages { get; set; }
        public IEnumerable<HttpPostedFileBase> Scripts { get; set; }
    }
}