using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class File : Entity
    {
        protected File()
        {

        }

        internal File(string name, string extension, string relativePath)
        {
            Name = name;
            Extension = extension;
            RelativePath = relativePath;
        }

        public string Name { get; private set; }
        public string Extension { get; private set; }
        public string RelativePath { get; private set; }
        public int BuildId { get; private set; }
        public Build Build { get; private set; }
        public int PackageId { get; private set; }
        public Package Package { get; private set; }

        public void AssociateToBuild(int buildId)
        {
            BuildId = buildId;
        }
    }
}
