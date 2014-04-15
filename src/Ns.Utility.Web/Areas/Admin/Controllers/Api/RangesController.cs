using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Web.Areas.Admin.Models;
using Ns.Utility.Web.Framework.Api;
using Ns.Utility.Web.Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ns.Utility.Web.Areas.Admin.Controllers.Api
{
    public class RangesController : ApiControllerBase<Range, RangeModel>
    {
        public RangesController(IRepository<Range> repository, ICollectionModelMapper<Range, RangeModel> mapper)
            : base(repository, mapper)
        {

        }
    }
}