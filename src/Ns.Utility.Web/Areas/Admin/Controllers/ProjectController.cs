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

        public async Task<ActionResult> AddEdit(int? id)
        {
            ProjectModel model = new ProjectModel();
            if(id.HasValue)
            model = await ApiUtility.GetAsyncById<ProjectModel>(Services.Projects, id.Value);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(ProjectModel model)
        {
            bool response = false;
            if(model.IsNew)
            {
                response = await ApiUtility.PostAsync<ProjectModel>(Services.Projects, model);
            }
            else
            {
                response = await ApiUtility.PutAsync<ProjectModel>(Services.Projects, model);
            }

            if (response)
            {
                return RedirectToAction("List");
            }

            return View(model);
        }
    }
}