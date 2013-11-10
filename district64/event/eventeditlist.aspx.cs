using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class event_eventeditlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;
        IList<EventRequest> list = null;

        list = manager.retrieveEventList(false, this.CheckBoxUnapproved.Checked,
            this.CheckBoxOnlyActive.Checked, this.CheckBoxNotYetPast.Checked);

        this.GridViewEvents.DataSource = list;
        this.GridViewEvents.DataBind();
    }
}
