using Ns.Utility.Core.Service;
using Ns.Utility.Framework.Helper;
using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Areas.Deployment.Models;
using Ns.Utility.Web.Framework;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Areas.Deployment.Controllers
{
    public class BuildController : Controller
    {
        private IFileUploader uploader;

        public BuildController(IFileUploader uploader)
        {
            this.uploader = uploader;
        }

        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> AddEdit(int? id)
        {
            var model = new BuildViewModel();
            if (id.HasValue)
            {
                model = await ApiUtility.GetAsyncById<BuildViewModel>(Services.Builds, id.Value);
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
        public async Task<ActionResult> AddEdit(BuildViewModel model)
        {
            bool response = false;
            var apiModel = new BuildModel { Name = model.Name, ChangeSet = model.ChangeSet, Release = model.Release, ProjectId = model.ProjectId, ProjectName = model.ProjectName };

            #region Upload Files

            foreach (var package in model.Packages)
            {
                var file = uploader.Upload(package, model.Release, Path.GetFileName(package.FileName));
                apiModel.Packages.Add(new PackageModel { Name = file.Name, Path = file.Location });
            }

            foreach (var script in model.Scripts)
            {
                var file = uploader.Upload(script, model.Release, Path.GetFileName(script.FileName));
                apiModel.Scripts.Add(new FileModel { Name = file.Name, Extension = file.Extension, RelativePath = file.Location });
            }

            #endregion

            if (model.IsNew)
            {
                response = await ApiUtility.PostAsync<BuildModel>(Services.Builds, apiModel);
            }
            else
            {
                response = await ApiUtility.PutAsync<BuildModel>(Services.Builds, apiModel);
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