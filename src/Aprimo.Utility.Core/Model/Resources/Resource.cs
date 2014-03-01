using Aprimo.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Core.Model.Resources
{
    [DomainSignature]
    public class Resource : Entity
    {
        protected Resource()
        {

        }

        internal Resource(string text, string description)
        {
            Text = text;
            Description = description;
        }

        public string Text { get; private set; }
        public string Description { get; private set; }
    }
}
