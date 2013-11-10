using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using DistrictModel;


public partial class district : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SessionManager manager = (SessionManager)Session[SessionManager.SESSION_MANAGER];

        if (!IsPostBack)
        {
            //add onfocus/onblur event to all input controls
            JavascriptFactory.SetAllInputControlsColors(this, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText,
                System.Drawing.Color.LightBlue, System.Drawing.SystemColors.WindowText);

            string fileName = this.Page.Request.Url.ToString();
            fileName = fileName.Remove(0, fileName.LastIndexOf("/") + 1);
            if (fileName.IndexOf("?") >= 0) 
                 fileName = fileName.Remove(fileName.LastIndexOf("?"), fileName.Length - fileName.LastIndexOf("?"));

            bool test = checkPageAccessAgainstUser(fileName, manager.LoginUser, manager);
            if (!test)
                Response.Redirect("/district64/info/unauthorized.aspx");
        }

        
        if (manager.LoginUser != null)
        {
            this.showUserName(manager);
        }
        else
            this.MultiViewlogin.SetActiveView(this.ViewLogin);
        
    }

    private void showUserName(SessionManager manager)
    {
        this.MultiViewlogin.SetActiveView(this.ViewLogOutUserName);
        this.LiteralUserName.Text = "Welcome: " + manager.LoginUser.app_user_name;
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        SessionManager manager = (SessionManager)Session[SessionManager.SESSION_MANAGER];

        String message = manager.UserManager.loginUser(this.TextBoxUserName.Text.Trim(), this.TextBoxPassword.Text);
        if (message.Equals(UserManager.LOGIN_SUCCESS))
        {
            manager.LoginUser = manager.UserManager.getAppUser(this.TextBoxUserName.Text.Trim());
            this.showUserName(manager);
            
        }
        else
            this.LabelLoginMessage.Text = message;

    }

    public bool checkPageAccessAgainstUser(String page, app_user appUser, SessionManager manager)
    {
        bool accessible = false;
        Int32? level=null;

        /*system needs to check access level
         * the level is hierarchtical, so we can use less than or greater than
         * for defining access
         * */
        level = CacheWrapper.getPageAccessLevelCache(Cache, manager.UserManager, page);
       
        if (level == null || level.Equals(4))
            accessible = true;
        else if (appUser == null)
            accessible = false;
        else if (level >= appUser.access_level.access_level_id)
            accessible = true;
        else
            accessible = false;

        return accessible;
    }

    protected void MultiViewlogin_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SessionManager manager = (SessionManager)Session[SessionManager.SESSION_MANAGER];
        manager.LoginUser = null;
        this.MultiViewlogin.SetActiveView(this.ViewLogin);

    }

    protected void LinkButtonArchive_Click(object sender, EventArgs e)
    {

        long id=0;
        if ( ((SessionManager)Session[SessionManager.SESSION_MANAGER]).LoginUser != null)
            id = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).LoginUser.user_id;

        HttpCookie cookie = new HttpCookie("SessionRequestor");
        cookie.Value = id.ToString();
        cookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookie);

        string url = WebConfigurationManager.AppSettings["ArchiveUrl"];
        Response.Redirect(url);
    }
}
