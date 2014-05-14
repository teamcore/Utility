using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class Script : Entity
    {
        protected Script() : this(string.Empty, string.Empty, string.Empty)
        {

        }

        internal Script(string name, string extension, string path)
        {
            Name = name;
            Extension = extension;
            Path = path;
        }

        public string Name { get; private set; }
        public string Extension { get; private set; }
        public string Path { get; private set; }
        public int BuildId { get; private set; }
        public Build Build { get; private set; }

        public void AssociateToBuild(int buildId)
        {
            BuildId = buildId;
        }
    }
}
