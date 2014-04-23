using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework;
using Ns.Utility.Web.Framework.Mvc;
using Ns.Utility.Web.Framework.Security;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Controllers
{
    public class ProfileController : UtilityController
    {
        SessionHelper helper;

        public ProfileController(SessionHelper helper)
        {
            this.helper = helper;
        }

        public async Task<ActionResult> Index()
        {
            var model = await ApiUtility.GetAsyncById<UserModel>(Services.Users, UserSession.UserId);
            if(!model.IsNew)
            {
                var project = await ApiUtility.GetAsyncById<ProjectModel>(Services.Projects, model.ProjectId);
                if (project != null)
                {
                    model.ProjectName = project.Name;
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit()
        {
            var model = await ApiUtility.GetAsyncById<UserModel>(Services.Users, UserSession.UserId);
            var projects = await ApiUtility.GetAsync<ProjectModel>(Services.Projects);
            model.Projects.AddRange(projects);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserModel model)
        {
            var response = await ApiUtility.PutAsync<UserModel>(Services.Users, model);
            if (response)
            {
                helper.SetPrincipal(WindowsIdentity.GetCurrent().Name);
                return RedirectToAction("Index");
            }

            return View();
        }
	}
}