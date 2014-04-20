using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Ns.Utility.Web.Areas.Admin.Models;
using System.Configuration;
using Ns.Utility.Web.Framework;

namespace Ns.Utility.Web.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> AddEdit(int id)
        {
            var project = await ApiUtility.GetAsync<ProjectModel>(string.Format("{0}/{1}", Services.Projects, id));
            return View(project.FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(ProjectModel model)
        {
            var response = await ApiUtility.PostAsync<ProjectModel>(Services.Projects, model);
            if (response)
            {
                return RedirectToAction("List");
            }

            return View(model);
        }
    }
}