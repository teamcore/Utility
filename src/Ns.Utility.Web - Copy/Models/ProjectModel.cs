using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Models
{
    public class ProjectModel : BaseEntityModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}