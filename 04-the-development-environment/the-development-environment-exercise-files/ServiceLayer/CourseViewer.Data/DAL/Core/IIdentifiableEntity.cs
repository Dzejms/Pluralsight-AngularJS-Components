using System;
using System.Collections.Generic;
using System.Linq;

namespace Melvicorp.Data
{
    public interface IIdentifiableEntity
    {
    }

    public interface IIdentifiableEntity<T> : IIdentifiableEntity
    {
        T EntityId { get; set; }
    }
}
