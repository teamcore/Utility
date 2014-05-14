using Ns.Utility.Core.Service;
using Ns.Utility.Framework.DomainModel;
using Ns.Utility.Framework.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class Package : Entity
    {
        protected Package() : this(string.Empty, string.Empty, string.Empty)
        {
            
        }

        internal Package(string name, string path, string description = "")
        {
            Name = name;
            Path = path;
            Description = description;
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
        public string Description { get; private set; }
        public int BuildId { get; private set; }
        public Build Build { get; private set; }

        public void AssociateToBuild(int buildId)
        {
            BuildId = buildId;
        }
    }
}
