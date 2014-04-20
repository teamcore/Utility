using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Mapper;
using System.Web.Http;

namespace Ns.Utility.Web.Areas.Admin.Controllers.Api
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiControllerBase<Project, ProjectModel>
    {
        public ProjectsController(IRepository<Project> repository, ICollectionModelMapper<Project, ProjectModel> mapper)
            : base(repository, mapper)
        {

        }
    }
}
