using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.DataAccess.Repository
{
    /// <summary>
    /// Interface used for user access repository pattern
    /// </summary>
    public interface IAppUserRepository : IRespository<AppUser, long>
    {
    }
}
