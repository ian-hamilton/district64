using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using District64.District64Wcf.DataAccess.Repository;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.InternalService
{
    public class AppUserService
    {
        IAppUserRepository _userRepository;

        /// <summary>
        /// Parameterized constructor injecting the User Respository
        /// </summary>
        /// <param name="userRepository">Repository for App Users</param>
        public AppUserService(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Checks to see if the provided user id has this route or page 
        /// and is accessible
        /// </summary>
        /// <param name="userId">The user id to base results</param>
        /// <param name="pageRoute">the page name or route name</param>
        /// <returns></returns>
        public bool HasPageOrRouteLevelAccess(long userId, string pageRoute)
        {
            AppUser user = _userRepository.Read(userId);
            if (user == null) return false;

            return (user.AccessLevel.AllowedPages.Contains(new AppUserAccessLevelPageAccess() { Page = pageRoute }));               
        }
    }
}
