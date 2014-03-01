using System.Data.Entity;
using Aprimo.Utility.Framework.Data.Contract;

namespace Aprimo.Utility.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region private Fields

        private readonly DbContext context;

        #endregion

        #region ctor

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        #endregion
        
        #region IUnitOfWork Members

        public void Commit()
        {
            context.SaveChanges();
        }
        
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            context.Dispose();
        }

        #endregion
    }
}