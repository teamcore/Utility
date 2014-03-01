using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Core.Model.Projects
{
    public class ProjectFactory : IProjectFactory
    {
        public Project Create(string name, string code, string description)
        {
            return new Project(name, code, description);
        }
    }
}
