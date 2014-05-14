using Ns.Utility.Framework.Mvc;
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
            Packages = new HashSet<PackageModel>();
            Scripts = new HashSet<SqlScriptModel>();
        }

        public string Name { get; set; }
        public string ChangeSet { get; set; }
        public string Release { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public ICollection<PackageModel> Packages { get; set; }
        public ICollection<SqlScriptModel> Scripts { get; set; }
    }
}