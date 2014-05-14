using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Areas.Deployment.Models
{
    public class SqlScriptModel: BaseEntityModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
    }
}