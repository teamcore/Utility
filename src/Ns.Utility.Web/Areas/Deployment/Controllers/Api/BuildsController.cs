using Ns.Utility.Core.Model.Builds;
using Ns.Utility.Core.Service;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Deployment.Models;
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
        IRepository<Package> packageRepository;

        public BuildsController(IRepository<Build> repository, IRepository<Package> packageRepository, ICollectionModelMapper<Build, BuildModel> mapper)
            : base(repository, mapper)
        {
            this.packageRepository = packageRepository;
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
        public void Post(ProcessModel model)
        {
            //var entity = repository.Get(model.Id);
            var packages = packageRepository.Find(x => x.BuildId == model.Id);
            foreach (var package in packages)
            {
                package.ExtractFiles();
                packageRepository.Update(package);
            }
        }
    }
}
