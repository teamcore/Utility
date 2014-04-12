using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ns.Utility.Web.Framework.Kendo
{
    public class KendoResult<T>
    {
        public IEnumerable<T> Data { get; private set; }
        public int Count { get; private set; }
        public string Errors { get; private set; }

        public KendoResult(IEnumerable<T> data, int count)
        {
            Data = data;
            Count = count;
        }

        public KendoResult(string errors)
        {
            Errors = errors;
        }
    }
}