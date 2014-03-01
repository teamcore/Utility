using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aprimo.Utility.Core.Model.Projects;
using Aprimo.Utility.UnitTests.Helper;
using NUnit.Framework;
using FluentAssertions;

namespace Aprimo.Utility.UnitTests.Data
{
    [TestFixture]
    internal class ProjectRepositoryTest : RepositoryTest<Project>
    {
        private IProjectFactory factory;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            factory = new ProjectFactory();
        }

        [Test, Category("Database")]
        public void add_new_project()
        {
            var project = factory.Create("Kraft Foods", "Kraft", string.Empty);
            var result = SaveAndLoadEntity(project);
            
        }
    }
}
