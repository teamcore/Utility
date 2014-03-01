using System;
using System.IO;
using Ns.Utility.Framework;
using FluentAssertions;
using NUnit.Framework;

namespace Ns.Utility.UnitTests.Helper
{
    internal class SchemaTest : PersistenceTest
    {
        [Category("Database")]
        [Test]
        public void GenerateSchema()
        {
            try
            {
                var result = context.GenerateScript();
                result.Should();
                using (TextWriter writer = new StreamWriter("../../../../db/schema.sql"))
                {
                    writer.Write(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
