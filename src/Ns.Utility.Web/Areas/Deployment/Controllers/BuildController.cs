using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Areas.Deployment.Models;
using Ns.Utility.Web.Framework;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Areas.Deployment.Controllers
{
    public class BuildController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> AddEdit(int? id)
        {
            var model = new BuildModel();
            if (id.HasValue)
            {
                model = await ApiUtility.GetAsyncById<BuildModel>(Services.Builds, id.Value);
                if (!model.IsNew)
                {
                    var project = await ApiUtility.GetAsyncById<ProjectModel>(Services.Projects, model.ProjectId);
                    if (project != null)
                    {
                        model.ProjectName = project.Name;
                        model.Projects.Add(project);
                    }
                }
            }
            else
            {
                var projects = await ApiUtility.GetAsync<ProjectModel>(Services.Projects);
                model.Projects.AddRange(projects);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(BuildModel model)
        {
            bool response = false;
            if (model.IsNew)
            {
                response = await ApiUtility.PostAsync<BuildModel>(Services.Builds, model);
            }
            else
            {
                response = await ApiUtility.PutAsync<BuildModel>(Services.Builds, model);
            }

            if (response)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }

        public ActionResult Preview(int id)
        {
            return View();
        }
	}
}