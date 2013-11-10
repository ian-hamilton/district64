using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.Domain.Criterions;

namespace District64.District64Wcf.DataAccess.Repository
{
    /// <summary>
    /// Base interface for all Repository 
    /// patterns in this project
    /// </summary>
    /// <typeparam name="TEntity">The Aggregate Entity type for the repositry implementation</typeparam>
    /// <typeparam name="TId">The ID or PK for the entity</typeparam>
    public interface IRespository<TEntity, TId>
    {
        TEntity Read(TId id);        
        TId SaveOrUpdate(TEntity transient);
    }
}
