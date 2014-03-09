using Ns.Utility.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aprimo.Utility.Web.Models
{
    public class LoginResponse : BaseEntityModel
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}