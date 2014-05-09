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
        public File(string name, string extension, string relativePath)
        {
            Name = name;
            Extension = extension;
            RelativePath = relativePath;
        }

        public string Name { get; private set; }
        public string Extension { get; private set; }
        public string RelativePath { get; private set; }
    }
}
