using System;
using System.Runtime.Caching;
using Aprimo.Utility.Data;
using Aprimo.Utility.Framework.Caching;
using Aprimo.Utility.Framework.Data.Contract;
using Aprimo.Utility.Framework.DomainModel;
using NUnit.Framework;

namespace Aprimo.Utility.UnitTests.Helper
{
    [TestFixture]
    internal class RepositoryTest<T> : PersistenceTest where T : Entity
    {
        protected IRepository<T> repository;
        protected IUnitOfWork unitOfWork;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            unitOfWork = new UnitOfWork(context);
            repository = new Repository<T>(context, new MemoryCacheProvider(), new CacheItemPolicy());
        }

        [TearDown]
        public override void TearDown()
        {
            unitOfWork.Dispose();
            base.TearDown();
        }

        protected T SaveAndLoadEntity(T entity)
        {
            try
            {
                repository.Add(entity);
                unitOfWork.Commit();
                int id = entity.Id;

                var fromDb = repository.Get(id);
                return fromDb;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
