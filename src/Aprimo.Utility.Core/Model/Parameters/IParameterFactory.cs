using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aprimo.Utility.Core.Model.Parameters
{
    public interface IParameterFactory
    {
        Parameter Create(int number, string name, string description, string value, string validValue, int resourceId, bool isVisible, int groupId, int dispalyOrder);
    }
}
