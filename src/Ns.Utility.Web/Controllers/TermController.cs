using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Controllers
{
    public class TermController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> AddEdit()
        {
            var projects = await ApiUtility.GetAsync<ProjectModel>(Services.Projects);
            var model = new TermModel();
            model.Projects.AddRange(projects);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(TermModel model)
        {
            var response = await ApiUtility.PostAsync<TermModel>(Services.Terms, model);
            if (response)
            {
                return RedirectToAction("List");
            }

            return View(model);
        }
	}
}