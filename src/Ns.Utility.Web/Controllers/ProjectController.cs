using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Ns.Utility.Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult AddEdit()
        {
            return View(new ProjectModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(ProjectModel model)
        {
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                client.BaseAddress = new Uri("http://localhost:2043/");
                var response = await client.PostAsJsonAsync<ProjectModel>("api/projects", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
            }

            return View(model);
        }
    }
}