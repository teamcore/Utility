using System;

namespace Aprimo.Utility.Framework.Data.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
