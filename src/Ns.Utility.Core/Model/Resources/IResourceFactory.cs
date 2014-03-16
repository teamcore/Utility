using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Resources
{
    public interface IResourceFactory
    {
        Resource CreateResource(string text, string description);
        Term CreateTerm(string text, string description);
    }
}
