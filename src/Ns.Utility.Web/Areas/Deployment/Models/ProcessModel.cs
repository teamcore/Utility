using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Areas.Deployment.Models
{
    public class ProcessModel : BaseEntityModel
    {
        public string BuildName { get; set; }
    }
}