using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class schedule_meetingrequestlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            this.fillGrid();
        }
    }

    private void fillGrid()
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        System.Collections.Generic.IList<FormattedMeetingBase> list = manager.retrieveOrderedApprovalNeededList();

        this.GridViewSchedule.DataSource = list;
        this.GridViewSchedule.DataBind();
    }
}
