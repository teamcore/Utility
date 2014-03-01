using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Ranges
{
    public class RangeFactory : IRangeFactory
    {
        #region IRangeFactory Members

        public Range Create(string name, string description, int min, int max, int projectId)
        {
            return new Range(name, description, min, max, projectId);
        }

        public Range Create(string name, int min, int max, int projectId)
        {
            return new Range(name, min, max, projectId);
        }

        #endregion
    }
}
