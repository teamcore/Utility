using Ns.Utility.Core.Model.Builds;
using Ns.Utility.Core.Service;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Deployment.Models;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Data.Entity;

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
            foreach (var package in entity.Packages)
            {
                package.AssociateToBuild(entity.Id);
            }

            foreach (var script in entity.Scripts)
            {
                script.AssociateToBuild(entity.Id);
            }

            repository.Add(entity);
        }

        [Route("process")]
        public void PostProcess(BuildModel model)
        {
            var entity = repository.AsQueryable().Include(x => x.Packages).FirstOrDefault(x => x.Id == model.Id);
            entity.BuildFileList();
            repository.Update(entity);
        }
    }
}
