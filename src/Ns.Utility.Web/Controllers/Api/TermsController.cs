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
    [RoutePrefix("api/terms")]
    public class TermsController : ApiControllerBase<Term, TermModel>
    {
        private readonly IRepository<Range> rangeRepository;

        public TermsController(IRepository<Term> repository, IRepository<Range> rangeRepository, ICollectionModelMapper<Term, TermModel> mapper)
            : base(repository, mapper)
        {
            this.rangeRepository = rangeRepository;
        }

        public override void Post(TermModel model)
        {
            var range = rangeRepository.Get(model.ProjectId);
            model.Key = range.GetNextId().ToString();
            var entity = mapper.Map(model);
            repository.Add(entity);
        }

        [Route("replace")]
        public IHttpActionResult Post(IList<string> texts)
        {
            string text = string.Empty;
            var terms = repository.Find(x => texts.Contains(x.Text));
            foreach (var item in texts)
            {
                var term = terms.FirstOrDefault(x => x.Text.Equals(item, StringComparison.OrdinalIgnoreCase));
                if(term != null)
                {
                    text += string.IsNullOrEmpty(text) ? string.Format("[{0}]", term.Id) : string.Format(" [{0}]", term.Id);
                    continue;
                }

                text += string.IsNullOrEmpty(text) ? string.Format("{0}", item) : string.Format(" {0}", item);
            }

            return Ok(text);
        }
    }
}
