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

        public async Task<ActionResult> AddEdit()
        {
            var projects = await ApiUtility.GetAsync<ProjectModel>(Services.Projects);
            var model = new ResourceModel();
            model.Projects.AddRange(projects);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(ResourceModel model)
        {
            var response = await ApiUtility.PostAsync<ResourceModel>(Services.Resources, model);
            if(response)
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