using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Areas.Deployment.Models
{
    public class BuildModel : BaseEntityModel
    {
        public BuildModel()
        {
            Projects = new List<ProjectModel>();
            Packages = new List<HttpPostedFile>();
            Scripts = new List<HttpPostedFile>();
        }

        public string Name { get; set; }
        public string ChangeSet { get; set; }
        public string Release { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectModel> Projects { get; set; }
        public IList<HttpPostedFile> Packages { get; set; }
        public IList<HttpPostedFile> Scripts { get; set; }
    }
}