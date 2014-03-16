using Ns.Utility.Core.Model.Ranges;
using Ns.Utility.Core.Model.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [TestCase]
        public void generate_script_for_resource()
        {

        }
    }
}
