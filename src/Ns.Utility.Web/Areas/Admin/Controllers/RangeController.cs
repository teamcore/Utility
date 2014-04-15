using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ns.Utility.Web.Areas.Admin.Controllers
{
    public class RangeController : Controller
    {
        private IRepository<Project> repository;
        private ICollectionModelMapper<Project, ProjectModel> mapper;

        public RangeController(IRepository<Project> repository, ICollectionModelMapper<Project, ProjectModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public ActionResult List()
        {
            return View();
        }

        public ActionResult AddEdit()
        {
            var projects = mapper.Map(repository.GetAll());
            var model = new RangeModel();
            model.Projects.AddRange(projects);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEdit(RangeModel model)
        {
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                client.BaseAddress = new Uri("http://localhost:2043/");
                var response = await client.PostAsJsonAsync<RangeModel>("api/ranges", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
            }

            return View();
        }
	}
}