using Ns.Utility.Framework.Mvc;
using Ns.Utility.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Framework.Mvc
{
    public class BaseViewModel : BaseEntityModel
    {
        public IUserSession Session { get; set; }
    }
}