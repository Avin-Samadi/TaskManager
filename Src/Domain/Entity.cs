using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Domain
{
    public abstract class Entity<TId> : IEntity<TId>
        where TId : notnull
    {
        public TId Id { get; }

        protected Entity(TId id) => Id = id;
    }
}
