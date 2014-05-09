using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public class BuildFactory : IBuildFactory
    {
        public Build CreateBuild(string name, string changeSet, string release, int projectId)
        {
            return new Build(name, changeSet, release, projectId);
        }

        public Package CreatePackage(string name, string path, float size, string description = "")
        {
            return new Package(name, path, size, description);
        }

        public File CreateFile(string name, string extension, string relativePath)
        {
            return new File(name, extension, relativePath);
        }
    }
}
