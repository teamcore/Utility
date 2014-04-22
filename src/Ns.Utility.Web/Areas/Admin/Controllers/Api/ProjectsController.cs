using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Mapper;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace Ns.Utility.Web.Areas.Admin.Controllers.Api
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiControllerBase<Project, ProjectModel>
    {
        public ProjectsController(IRepository<Project> repository, ICollectionModelMapper<Project, ProjectModel> mapper)
            : base(repository, mapper)
        {

        }

        [Route("norange")]
        public IEnumerable<ProjectModel> GetProjectsHasNoRange()
        {
            var entities = repository.AsQueryable().Where(x => x.HasRange == false);
            var models = mapper.Map(entities);
            return models;
        }
    }
}
