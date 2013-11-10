using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DistrictModel;

/// <summary>
/// Summary description for SessionManager
/// </summary>
public class SessionManager
{
    public const String SESSION_MANAGER = "sessionManager";

    private ScheduleManager _scheduleManager;
    private UserManager _userManager;
    private EventManager _eventManager;

    /* this is used for security */
    private app_user loginUser;

    public app_user LoginUser
    {
        get { return loginUser; }
        set { loginUser = value; }
    }

	public SessionManager()
	{
        this._scheduleManager = new ScheduleManager();
        this._userManager = new UserManager();
        this._eventManager = new EventManager();
    }


    public ScheduleManager ScheduleManager
    {
        get { return _scheduleManager; }
    }
    public UserManager UserManager
    {
        get { return _userManager; }
    }
    public EventManager EventManager
    {
        get { return _eventManager; }
    }
}
