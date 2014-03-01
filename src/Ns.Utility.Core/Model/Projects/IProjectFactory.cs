using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Projects
{
    public interface IProjectFactory
    {
        Project Create(string name, string code, string description);
    }
}
