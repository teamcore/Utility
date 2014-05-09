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
using System.Web.Http;

namespace Ns.Utility.Web.Areas.Deployment.Controllers.Api
{
    [RoutePrefix("api/builds")]
    public class BuildsController : ApiControllerBase<Build, BuildModel>
    {
        private IFileUploader uploader;
        public BuildsController(IRepository<Build> repository, ICollectionModelMapper<Build, BuildModel> mapper, IFileUploader uploader)
            : base(repository, mapper)
        {
            this.uploader = uploader;
        }

        public override void Post(BuildModel model)
        {
            foreach (var package in model.Packages)
            {
                var file = uploader.Upload(package, model.Name, model.Name);
            }

            foreach (var script in model.Scripts)
            {
                var file = uploader.Upload(script, model.Name, model.Name);
            }

            //base.Post(model);
        }
    }
}
