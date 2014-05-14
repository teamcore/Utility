using Ns.Utility.Core.Model.Builds;
using Ns.Utility.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Data.Mapping.Core
{
    public class ScriptMap : EntityMapping<Script>
    {
        public ScriptMap()
        {
            HasRequired(x => x.Build).WithMany(x => x.Scripts).HasForeignKey(x => x.BuildId).WillCascadeOnDelete(false);
        }
    }
}
