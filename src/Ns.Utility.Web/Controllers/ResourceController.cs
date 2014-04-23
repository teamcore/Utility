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
    public class ResourceController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> AddEdit(int? id)
        {
            var model = new ResourceModel();
            if(id.HasValue)
            {
                model = await ApiUtility.GetAsyncById<ResourceModel>(Services.Resources, id.Value);
                if (!model.IsNew)
                {
                    var project = await ApiUtility.GetAsyncById<ProjectModel>(Services.Projects, model.ProjectId);
                    model.ProjectName = project.Name;
                    model.Projects.Add(project);
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
        public async Task<ActionResult> AddEdit(ResourceModel model)
        {
            bool response = false;
            if (model.IsNew)
            {
                response = await ApiUtility.PostAsync<ResourceModel>(Services.Resources, model);
            }
            else
            {
                response = await ApiUtility.PutAsync<ResourceModel>(Services.Resources, model);
            }

            if (response)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Preview(IList<int> ids)
        {
            return RedirectToAction("Preview");
        }

        public ActionResult Preview()
        {
            return View();
        }
	}
}