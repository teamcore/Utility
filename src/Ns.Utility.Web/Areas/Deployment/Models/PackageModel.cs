using Ns.Utility.Core.Shared;
using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Areas.Deployment.Models
{
    public class PackageModel : BaseEntityModel
    {
        public PackageModel()
        {

        }

        public string Name { get; set; }
        public string Path { get; set; }
        public float Size { get; set; }
        public string Description { get; set; }
    }
}