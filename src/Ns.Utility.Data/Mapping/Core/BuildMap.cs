using Ns.Utility.Core.Model.Builds;
using Ns.Utility.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Data.Mapping.Core
{
    public class BuildMap : EntityMapping<Build>
    {
        public BuildMap() : base()
        {
            HasMany(x => x.Packages);
            HasMany(x => x.Scripts);
        }
    }
}
