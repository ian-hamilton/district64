using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class schedule_meetingchangelist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        if (!IsPostBack)
        {
            this.fillGrid(null);
        }
    }

    protected void GridViewSchedule_Sorting(object sender, GridViewSortEventArgs e)
    {
        this.fillGrid(e.SortExpression);
    }

    private void fillGrid(String orderBy)
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        System.Collections.Generic.IList<FormattedMeetingBase> list = manager.retrieveOrderedActiveMeetingList
            (true,
            -1,
            null,
            null,
            orderBy);

        this.GridViewSchedule.DataSource = list;
        this.GridViewSchedule.DataBind();
    }
}
