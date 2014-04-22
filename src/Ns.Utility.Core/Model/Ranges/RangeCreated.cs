using Ns.Utility.Core.Model.Projects;
using Ns.Utility.Framework.DomainModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Ranges
{
    public class RangeCreated : IDomainEvent
    {
        public RangeCreated(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; private set; }
    }
}
