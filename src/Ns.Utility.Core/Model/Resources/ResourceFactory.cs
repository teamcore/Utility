using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Framework.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Resources
{
    public class ResourceFactory : IResourceFactory
    {
        private Range range;
        public ResourceFactory(Range range)
        {
            this.range = range;
        }
        public Resource CreateResource(string text, string description)
        {
            var key = range.GetNextId();
            return new Resource(key, text, description);
        }

        public Term CreateTerm(string text, string description)
        {
            var key = range.GetNextId();
            return new Term(key, text, description);
        }
    }
}
