using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Builds
{
    public interface IBuildFactory
    {
        Build CreateBuild(string name, string changeSet, string release, int projectId);

        Package CreatePackage(string name, string path, string description = "");

        File CreateFile(string name, string extension, string relativePath);
    }
}
