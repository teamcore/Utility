using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Core.Model.Ranges
{
    public interface IRangeFactory
    {
        Range Create(string name, string description, int min, int max, int projectId);
        Range Create(string name, int min, int max, int projectId);
    }
}
