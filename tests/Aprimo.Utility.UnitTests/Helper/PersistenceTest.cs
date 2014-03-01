using Aprimo.Utility.Data;
using NUnit.Framework;

namespace Aprimo.Utility.UnitTests.Helper
{
    [TestFixture]
    internal class PersistenceTest
    {
        protected SmartContext context;

        [SetUp]
        public virtual void SetUp()
        {
            context = new SmartContext();
            context.Database.Delete();
            context.Database.Create();
        }

        public virtual void TearDown()
        {
            context.Dispose();
        }
    }
}
