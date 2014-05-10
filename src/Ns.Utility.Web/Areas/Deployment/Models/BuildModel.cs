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
            Packages = new List<PackageModel>();
            Scripts = new List<FileModel>();
        }

        public string Name { get; set; }
        public string ChangeSet { get; set; }
        public string Release { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public IList<PackageModel> Packages { get; set; }
        public IList<FileModel> Scripts { get; set; }
    }
}