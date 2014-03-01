using Ns.Utility.Core.Model.Groups;
using Ns.Utility.Core.Model.Resources;
using Ns.Utility.Framework.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Utility.Core.Model.Parameters
{
    [DomainSignature]
    public class Parameter : Entity
    {
        protected Parameter()
        {

        }

        internal Parameter(int number, string name, string description, string value, string validValue, int resourceId, bool isVisible, int groupId, int dispalyOrder)
        {
            Number = number;
            Name = name;
            Description = description;
            Value = value;
            ValieValue = validValue;
            ResourceId = resourceId;
            IsVisible = isVisible;
            GroupId = groupId;
            DisplayOrder = dispalyOrder;
        }

        public int Number { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Value { get; private set; }
        public string ValieValue { get; private set; }
        public Resource Resource { get; private set; }
        public int ResourceId { get; private set; }
        public bool IsVisible { get; private set; }
        public int GroupId { get; private set; }
        public Group Group { get; private set; }
        public int DisplayOrder { get; private set; }
    }
}
