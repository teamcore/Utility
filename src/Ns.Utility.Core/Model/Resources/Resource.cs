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
        const string INSERT_SCRIPT = @"INSERT INTO replacement_string_table VALUES ({0}, '{1}', 1, 1);
INSERT INTO completed_strings VALUES ({0}, 1, '{1}');";
        const string DELETE_SCRIPT = @"DELETE FROM replacement_string_table WHERE replacement_string_id = {0};
DELETE FROM completed_strings WHERE replacement_string_id = {0};";

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

            script += Environment.NewLine;
            script += string.Format(INSERT_SCRIPT, Key, Text);
            script += Environment.NewLine;
            script += Environment.NewLine;
            return script;
        }

        public IList<int> GetTermIds()
        {
            IList<int> terms = new List<int>();
            var arr = Text.Split(' ');
            foreach (var item in arr)
            {
                if(item.StartsWith("[") && item.EndsWith("]"))
                {
                    terms.Add(Convert.ToInt32(item.Replace("[", "").Replace("]", "")));
                }
            }

            return terms;
        }
    }
}
