using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Resources
{
    [DomainSignature]
    public class Resource : Entity
    {
        protected Resource()
        {

        }

        internal Resource(int key, string text, string description)
        {
            Key = key;
            Text = text;
            Description = description;
        }

        public int Key { get; private set; }
        public string Text { get; private set; }
        public string Description { get; private set; }

        public string Generate(bool ifExists)
        {
            const string insert = @"INSERT INTO replacement_string_table VALUES ({0},'{1}',1,1)
INSERT INTO completed_strings VALUES ({0},1,'{1}')";
            const string update = @"INSERT INTO replacement_string_table VALUES ({0},'{1}',1,1)
INSERT INTO completed_strings VALUES ({0},1,'{1}')";
            return string.Empty;
        }
    }
}
