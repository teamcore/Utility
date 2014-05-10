using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class Package : Entity
    {
        protected Package()
        {

        }
        internal Package(string name, string path, float size, string description = "")
        {
            Name = name;
            Path = path;
            Size = size;
            Description = description;
            Files = new List<File>();
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
        public float Size { get; private set; }
        public string Description { get; private set; }
        public IList<File> Files { get; private set; }

        public void ExtractFiles()
        {
            var files = Directory.EnumerateFiles(Path, "*.*", SearchOption.AllDirectories);
        }
    }
}
