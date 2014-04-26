using Kendo.DynamicLinq;
using Newtonsoft.Json;
using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Core.Model.Resources;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Kendo;
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
    [RoutePrefix("api/resources")]
    public class ResourcesController : ApiControllerBase<Resource, ResourceModel>
    {
        private readonly IRepository<Range> rangeRepository;
        private readonly IRepository<Term> termRepository;
        public ResourcesController(IRepository<Resource> repository, IRepository<Range> rangeRepository, IRepository<Term> termRepository, ICollectionModelMapper<Resource, ResourceModel> mapper)
            : base(repository, mapper)
        {
            this.rangeRepository = rangeRepository;
            this.termRepository = termRepository;
        }

        public override IHttpActionResult Get(HttpRequestMessage requestMessage)
        {
            if (requestMessage.RequestUri.ParseQueryString().Count > 0)
            {
                DataSourceRequest request = JsonConvert.DeserializeObject<DataSourceRequest>(requestMessage.RequestUri.ParseQueryString().GetKey(0));
                var entities = repository.AsQueryable().Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).ToDataSourceResult(request.Take, request.Skip, request.Sort, request.Filter);
                var datasource = new DataSourceResult
                {
                    Data = Post((IEnumerable<Resource>)entities.Data),
                    Total = entities.Total
                };

                return Ok<DataSourceResult>(datasource);
            }
            else
            {
                var entities = repository.GetAll();
                if (entities == null)
                {
                    return NotFound();
                }

                var models = Post(entities);
                return Ok<IEnumerable<ResourceModel>>(models);
            }
        }

        [Route("script")]
        public IHttpActionResult Post(IList<int> ids)
        {
            var entities = repository.AsQueryable().Where(x => ids.Contains(x.Id));
            var script = string.Empty;
            foreach (var entity in entities)
            {
                script += entity.Generate(true);
            }

            return Ok(script);
        }

        public override void Post(ResourceModel model)
        {
            var range = rangeRepository.Get(model.ProjectId);
            model.Key = range.GetNextId().ToString();
            var entity = mapper.Map(model);
            repository.Add(entity);
        }

        [Route("terms")]
        public IEnumerable<ResourceModel> Post(IEnumerable<Resource> resources)
        {
            List<int> termIds = new List<int>();
            foreach (var resource in resources)
            {
                termIds.AddRange(resource.GetTermIds());
            }

            var terms = termRepository.Find(x => termIds.Contains(x.Id));
            var termPairs = terms.ToDictionary(x => x.Id);

            foreach (var resource in resources)
            {
                resource.ReplaceWithTerm(termPairs);
            }

            return mapper.Map(resources);
        }
    }
}
