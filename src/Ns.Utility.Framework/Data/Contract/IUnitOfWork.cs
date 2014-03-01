using System;

namespace Ns.Utility.Framework.Data.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
