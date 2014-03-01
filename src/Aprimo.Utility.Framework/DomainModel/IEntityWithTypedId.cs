using System.Collections.Generic;
using System.Reflection;

namespace Aprimo.Utility.Framework.DomainModel
{
    /// <summary>
    ///     This serves as a base interface for <see cref="EntityWithTypedId{TId}" /> and 
    ///     <see cref = "Entity" />. Also provides a simple means to develop your own base entity.
    /// </summary>
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }

        IEnumerable<PropertyInfo> GetSignatureProperties();

        bool IsTransient();
    }
}