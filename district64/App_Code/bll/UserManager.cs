using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistrictModel;

/// <summary>
/// Summary description for UserManager
/// </summary>
public class UserManager
{
    public const String LOGIN_SUCCESS = "success";
    public const String LOGIN_FAILURE = "User/Password Not Correct";

	public UserManager()
	{}

    public Boolean isUser(String userName)
    {

        List<app_user> list = new List<app_user>();

        using (DistrictEntities ctx = new DistrictEntities())
        {
            int count = ctx.app_user.Where(ap=> ap.app_user_name.ToLower().Equals(userName.ToLower())).Count();

            if (count == 0)
                return false;
            else
                return true;
        }


    }

    public app_user getAppUser(String userName)
    {
        app_user user = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            user = ctx.app_user.Where(ap => ap.app_user_name.ToLower().Equals(userName.ToLower())).First<app_user>();
            user.access_levelReference.Load();

            user = ctx.app_user.Where(a => a.app_user_name.ToLower() == userName.ToLower()).First();
        }

        return user;
    }


    public app_user getAppUser(long userId)
    {
        app_user user = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {

            user = ctx.app_user.Where(au => au.user_id.Equals(userId)).First<app_user>();
            user.access_levelReference.Load();

        }

        return user;
    }

    //public bool checkPageAccessAgainstUser(String page, app_user appUser)
    //{
    //    bool accessible = false;
    //    using (DistrictEntities ctx = new DistrictEntities())
    //    {
    //        int count = ctx.page_access.Where(pa => pa.page.ToLower().Equals(page.ToLower())).Count();

    //        /*this means the page does not exist in the db and defaulty can be accessed anonymously*/
    //        if (count.Equals(0))
    //            accessible = true;
    //        else
    //        {
    //            /*system needs to check access level
    //             * the level is hierarchtical, so we can use less than or greater than
    //             * for defining access
    //             * */
    //            page_access pageAccess = ctx.page_access.Where(pa => pa.page.ToLower().Equals(page.ToLower())).First<page_access>();
    //            pageAccess.access_levelReference.Load();

    //            if (pageAccess.Equals(4))
    //                accessible = true;
    //            else if (appUser == null)
    //                accessible = false;
    //            else if (pageAccess.access_level.access_level_id >= appUser.access_level.access_level_id)
    //                accessible = true;
    //            else
    //                accessible = false;
    //        }         
    //    }

    //    return accessible;
    //}

    public IList<page_access> getPageAccess()
    {
        IQueryable result=null;
        IList<page_access> list;
        using (DistrictEntities ctx = new DistrictEntities())
        {
            result = ctx.page_access;

            list = new List<page_access>();

            foreach (page_access p in result)
            {                
                list.Add(p);
            }

            foreach (page_access p2 in list)
            {

                p2.access_levelReference.Load();
            }
        }
        
        return list;
    }


    public String loginUser(String enteredUsername, String enteredPassword)
    {

        if (!this.isUser(enteredUsername)) return LOGIN_FAILURE;

        app_user user = this.getAppUser(enteredUsername);
        if (!user.password.Equals(enteredPassword)) return LOGIN_FAILURE;

        return LOGIN_SUCCESS;
        
    }
}
