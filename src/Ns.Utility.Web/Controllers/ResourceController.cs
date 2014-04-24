using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<ActionResult> Preview(IList<int> ids)
        {
            var model = new ScriptModel();
            string script = await ApiUtility.PostAsync<IList<int>, string>(Services.ResourcesScript, ids);
            model.Script = script;
            model.ResourceIDs.AddRange(ids);
            return View(model);
        }

        [HttpPost]
        public async Task<FileContentResult> Export(IList<int> ids)
        {
            string script = await ApiUtility.PostAsync<IList<int>, string>(Services.ResourcesScript, ids);
            byte[] file = Encoding.ASCII.GetBytes(script);
            string filename = "sqlstript.sql";
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
            return File(file, "plain/text", filename);
        }
	}
}