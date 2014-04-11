using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Controllers
{
    public class GroupController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult AddEdit()
        {
            return View();
        }
	}
}