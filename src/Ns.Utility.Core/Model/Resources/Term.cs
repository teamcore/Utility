using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Resources
{
    [DomainSignature]
    public class Term : Entity
    {
        protected Term()
        {

        }

        internal Term(int? key, string text, string description)
        {
            Key = key;
            Text = text;
            Description = description;
        }

        public int? Key { get; private set; }
        public string Text { get; private set; }
        public string Description { get; private set; }
    }
}
