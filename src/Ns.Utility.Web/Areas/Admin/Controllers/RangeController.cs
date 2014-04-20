using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework;
using Ns.Utility.Web.Framework.Mapper;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Areas.Admin.Controllers
{
    public class RangeController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> AddEdit()
        {
            var projects = await ApiUtility.GetAsync<ProjectModel>(Services.Projects);
            var model = new RangeModel();
            model.Projects.AddRange(projects);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(RangeModel model)
        {
            var response = await ApiUtility.PostAsync<RangeModel>(Services.Ranges, model);
            if (response)
            {
                return RedirectToAction("List");
            }

            return View();
        }
	}
}