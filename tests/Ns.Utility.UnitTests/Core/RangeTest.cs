using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ns.Utility.Core.Model;
using NUnit.Framework;
using FluentAssertions;
using Ns.Utility.Framework.Exceptions;
using Ns.Utility.Core.Model.Ranges;

namespace Ns.Utility.Tests.Core
{
    [TestFixture]
    public class RangeTest
    {
        IRangeFactory factory;

        [SetUp]
        public void SetUp()
        {
            factory = new RangeFactory();
        }

        [Category("Business Rule")]
        [TestCase("", "This is a dummy identity range", 1, 5, 1)]
        [ExpectedException(typeof(FunctionalException), ExpectedMessage = "Name is mandatory.")]
        public void name_cannot_be_null_or_blank(string name, string description, int min, int max, int projectId)
        {
            var identity = factory.Create(name, description, min, max, projectId);
        }

        [Category("Business Rule")]
        [TestCase("Dummy Range", "This is a dummy identity range", 0, 5, 1)]
        [ExpectedException(typeof(FunctionalException), ExpectedMessage = "Min value cannot be zero.")]
        public void min_value_cannot_be_zero(string name, string description, int min, int max, int projectId)
        {
            var identity = factory.Create(name, description, min, max, projectId);
        }

        [Category("Business Rule")]
        [TestCase("Dummy Range", "This is a dummy identity range", 1, 0, 1)]
        [ExpectedException(typeof(FunctionalException), ExpectedMessage = "Max value cannot be zero.")]
        public void max_value_cannot_be_zero(string name, string description, int min, int max, int projectId)
        {
            var identity = factory.Create(name, description, min, max, projectId);
        }

        [Category("Business Rule")]
        [TestCase("Dummy Range", "This is a dummy identity range", 1, 5, 0)]
        [ExpectedException(typeof(FunctionalException), ExpectedMessage = "Project is mandatory.")]
        public void projectId_cannot_be_zero(string name, string description, int min, int max, int projectId)
        {
            var identity = factory.Create(name, description, min, max, projectId);
        }

        [Category("Business Rule")]
        [TestCase("Dummy Range", "This is a dummy identity range", 1, 5, 1)]
        [TestCase("Dummy Range", "This is a dummy identity range", 100, 105, 1)]
        public void when_new_range_added_will_be_available_for_next_id(string name, string description, int min, int max, int projectId)
        {
            var identity = factory.Create(name, description, min, max, projectId);
            var result = identity.GetNextId();
            Assert.AreEqual(min, result);
        }

        [Category("Business Rule")]
        [TestCase("Dummy Range", "This is a dummy identity range", 1, 5, 1)]
        [TestCase("Dummy Range", "This is a dummy identity range", 100, 105, 1)]
        public void when_identity_range_fully_utilized_it_will_update_isexhausted_flat(string name, string description, int min, int max, int projectId)
        {
            var identity = factory.Create(name, description, min, max, projectId);
            for (int i = min; i <= max; i++)
            {
                identity.GetNextId();
            }

            Assert.AreEqual(true, identity.IsExhausted);
        }

        [Category("Business Rule")]
        [TestCase("Dummy Range", "This is a dummy identity range", 1, 5, 1, 10)]
        [TestCase("Dummy Range", "This is a dummy identity range", 100, 105, 1, 110)]
        public void renew_identity_range_with_new_value(string name, string description, int min, int max, int projectId, int renew)
        {
            var identity = factory.Create(name, description, min, max, projectId);
            for (int i = min; i <= max; i++)
            {
                identity.GetNextId();
            }

            Assert.AreEqual(true, identity.IsExhausted);

            identity.Renew(renew);
            Assert.AreEqual(false, identity.IsExhausted);
            Assert.AreEqual(renew, identity.Max);
            Assert.AreEqual(max + 1, identity.GetNextId());
        }
    }
}
