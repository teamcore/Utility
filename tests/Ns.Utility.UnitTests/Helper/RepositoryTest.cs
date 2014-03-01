using System;
using System.Runtime.Caching;
using Ns.Utility.Data;
using Ns.Utility.Framework.Caching;
using Ns.Utility.Framework.Data.Contract;
using Ns.Utility.Framework.DomainModel;
using NUnit.Framework;

namespace Ns.Utility.UnitTests.Helper
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
