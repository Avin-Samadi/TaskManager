using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Contracts.Data
{
    public class PagedList<TEntity>(IEnumerable<TEntity> entities, int totalRecordCount)
    {
        public IReadOnlyList<TEntity> Entities => entities.ToList().AsReadOnly();
        public int TotalRecordCount => totalRecordCount;
    }
}
