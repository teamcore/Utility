using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Models
{
    public class UserModel : BaseEntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Domain { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}