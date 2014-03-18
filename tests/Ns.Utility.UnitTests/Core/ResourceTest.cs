using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Core.Model.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Ns.Utility.UnitTests.Core
{
    [TestFixture]
    public class ResourceTest
    {
        IRangeFactory rangeFactory;
        IResourceFactory factory;

        [SetUp]
        public void SetUp()
        {
            rangeFactory = new RangeFactory();
            var range = rangeFactory.Create("Dummy Range", 1, 10, 1);
            factory = new ResourceFactory(range);
        }

        [TestCase("Test Replacement String", "this is test description")]
        public void generate_resource_script(string text, string description)
        {
            var resource = factory.CreateResource(text, description);
            string script = resource.Generate(false);
            script.Should().NotBeNullOrEmpty();
            script.Should().Contain("INSERT INTO replacement_string_table");
            script.Should().Contain("INSERT INTO completed_strings");
        }
    }
}
