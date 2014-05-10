using Ns.Utility.Core.Model.Builds;
using Ns.Utility.Core.Service;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Deployment.Models;
using Ns.Utility.Web.Areas.Deployment.Models.Binder;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Ns.Utility.Web.Areas.Deployment.Controllers.Api
{
    [RoutePrefix("api/builds")]
    public class BuildsController : ApiControllerBase<Build, BuildModel>
    {
        public BuildsController(IRepository<Build> repository, ICollectionModelMapper<Build, BuildModel> mapper)
            : base(repository, mapper)
        {
            
        }

        public override void Post(BuildModel model)
        {
            var entity = mapper.Map(model);
            repository.Add(entity);

            foreach (var package in entity.Packages)
            {
                package.ExtractFiles();
                var files = package.Files;
            }
        }
    }
}
