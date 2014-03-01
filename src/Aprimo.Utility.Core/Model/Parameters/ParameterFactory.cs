using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Core.Model.Parameters
{
    public class ParameterFactory : IParameterFactory
    {
        public Parameter Create(int number, string name, string description, string value, string validValue, int resourceId, bool isVisible, int groupId, int dispalyOrder)
        {
            return new Parameter(number, name, description, value, validValue, resourceId, isVisible, groupId, dispalyOrder);
        }
    }
}
