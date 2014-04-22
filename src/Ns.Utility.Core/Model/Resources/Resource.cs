using Ns.Utility.Core.Model.Projects;
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
        const string INSERT_SCRIPT = @"INSERT INTO replacement_string_table VALUES ({0}, '{1}', 1, 1);\nINSERT INTO completed_strings VALUES ({0}, 1, '{1}');\n";
        const string DELETE_SCRIPT = @"\nDELETE FROM replacement_string_table WHERE replacement_string_id = {0};\nDELETE FROM completed_strings WHERE replacement_string_id = {0};\n";

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
        public Project Project { get; private set; }
        public int ProjectId { get; private set; }

        public string Generate(bool dropAndInsert)
        {
            string script = string.Empty;
            if(dropAndInsert)
            {
                script = string.Format(DELETE_SCRIPT, Key);
            }

            script += string.Format(INSERT_SCRIPT, Key, Text);
            return script;
        }
    }
}
