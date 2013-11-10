using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using District64.District64Wcf.DataAccess.Dao;
using District64.District64Wcf.DataAccess.Repository;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.DataAccess.Repository.Impl
{
    /// <summary>
    /// Repository for all AppUser
    /// Information
    /// </summary>
    public class AppUserRepository : IAppUserRepository
    {

        ObjectContext _context;

        private const string USER_TABLE_QUERY = "[app_user]";
        private const string PAGE_QUERY = "page_access";

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppUserRepository() { }

        /// <summary>
        /// Parameterized constructor with context injection
        /// </summary>
        /// <param name="context">Context, typically Database context
        /// but could be MOCK or other type of context</param>
        public AppUserRepository(ObjectContext context)
        {
            _context = context;
        }


        #region IRespository<AppUser,long> Members

        public AppUser Read(long id)
        {
            List<app_user> resultList = _context.CreateQuery<app_user>(USER_TABLE_QUERY).Where(x => x.user_id == id).ToList();
            if (resultList == null || resultList.Count == 0)
                return null;

            app_user result = resultList.First();
            result.access_levelReference.Load();

            IQueryable<page_access> objectQuery = 
                _context.CreateQuery<page_access>(PAGE_QUERY).Where(x=> x.min_access_level >= result.access_level.access_level_id);

            return LoadAppUser(result, objectQuery.ToList<page_access>());
        }

        /// <summary>
        /// Not allowing updates at this time
        /// just used for querying database
        /// </summary>
        /// <param name="transient"></param>
        /// <returns></returns>
        public long SaveOrUpdate(AppUser transient)
        {
            throw new NotImplementedException();
        }

        #endregion


        internal AppUser LoadAppUser(app_user result, List<page_access> pageAccessList)
        {
            AppUser appUser = new AppUser()
            {
                FirstName = result.user_first_name,
                LastName = result.user_last_name,
                IsValid = result.status_flag == 1,
                UserId = result.user_id
            };

            AppUserAccessLevel accessLevel = new AppUserAccessLevel()
            {
                AccessLevelDesc = result.access_level.access_level_desc,
                AccessLevelId = result.access_level.access_level_id
            };

            accessLevel.AllowedPages = new List<AppUserAccessLevelPageAccess>();


            foreach (page_access pageAccess in pageAccessList)
            {
                accessLevel.AllowedPages.Add(new AppUserAccessLevelPageAccess()
                {
                    Page = pageAccess.page,
                    PageAccessId = pageAccess.page_access_id
                });
            }            

            appUser.AccessLevel = accessLevel;

            return appUser;
        }
    }
}
