using Aprimo.Utility.Core.Model.Parameters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Aprimo.Utility.Tests.Core
{
    [TestFixture]
    public class SystemParameterTest
    {
        IParameterFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new ParameterFactory();
        }

        [Category("System Parameters")]
        [TestCase(1, "Dummy System Parameter", "Dummy System Parameter desription", "1", "NULL", 1, true, 1, 1)]
        public void generating_sql_script_with_if_not_exists(int number, string name, string description, string value, string validValue, int resourceId, bool isVisible, int groupId, int dispalyOrder)
        {
            var systemParameter = factory.Create(number, name, description, value, validValue, resourceId, isVisible, groupId, dispalyOrder);
            //string script = systemParameter.GenerateScript(true);
            //script.Should().Contain("IF NOT EXISTS (SELECT * FROM system_parameters WHERE system_parameter_id");
        }

        [Category("System Parameters")]
        [TestCase(1, "Dummy System Parameter", "Dummy System Parameter desription", "1", "NULL", 1, true, 1, 1)]
        public void generating_sql_script_without_if_not_exists(int number, string name, string description, string value, string validValue, int resourceId, bool isVisible, int groupId, int dispalyOrder)
        {
            var systemParameter = factory.Create(number, name, description, value, validValue, resourceId, isVisible, groupId, dispalyOrder);
            //string script = systemParameter.GenerateScript(false);
            //script.Should().Contain("INSERT INTO system_parameters");
        }
    }
}
