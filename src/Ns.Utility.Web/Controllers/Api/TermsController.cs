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
    public class TermsController : ApiControllerBase<Term, TermModel>
    {
        public TermsController(IRepository<Term> repository, ICollectionModelMapper<Term, TermModel> mapper)
            : base(repository, mapper)
        {
        }
    }
}
