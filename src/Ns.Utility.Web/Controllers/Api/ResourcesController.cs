using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Core.Model.Resources;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Mapper;
using Ns.Utility.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ns.Utility.Web.Controllers.Api
{
    public class ResourcesController : ApiControllerBase<Resource, ResourceModel>
    {
        private readonly IRepository<Range> rangeRepository;
        public ResourcesController(IRepository<Resource> repository, IRepository<Range> rangeRepository, ICollectionModelMapper<Resource, ResourceModel> mapper)
            : base(repository, mapper)
        {
            this.rangeRepository = rangeRepository;
        }

        public override void Post(ResourceModel model)
        {
            var range = rangeRepository.FindOne(x => x.ProjectId == model.ProjectId);
            model.Key = range.GetNextId().ToString();
            var entity = mapper.Map(model);
            repository.Add(entity);
        }
    }
}
