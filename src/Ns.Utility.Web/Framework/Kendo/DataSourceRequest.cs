using Kendo.DynamicLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Framework.Kendo
{
    public class DataSourceRequest
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public IEnumerable<Sort> Sort { get; set; }
        public Filter Filter { get; set; }
    }
}