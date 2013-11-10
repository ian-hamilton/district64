using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class event_eventlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;
        IList<EventRequest> list = null;      
            
        list = manager.retrieveEventList(true, false, true, true);

        this.GridViewEvents.DataSource = list;
        this.GridViewEvents.DataBind();
    }
}
