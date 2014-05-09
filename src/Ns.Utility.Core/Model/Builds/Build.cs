using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class Build : Entity
    {
        public Build(string name, string changeSet, string release, int projectId)
        {
            Name = name;
            ChangeSet = changeSet;
            Release = release;
            ProjectId = projectId;
            Packages = new List<Package>();
            Scripts = new List<File>();
        }

        public string Name { get; private set; }
        public string ChangeSet { get; private set; }
        public string Release { get; private set; }
        public int ProjectId { get; private set; }
        public Project Project { get; private set; }
        public IList<Package> Packages { get; private set; }
        public IList<File> Scripts { get; private set; }
    }
}
