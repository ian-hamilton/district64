using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class schedule_schedule : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;
        if (!IsPostBack)
        {
            this.DropDownListMeetingType.DataSource = manager.retreiveDistinctTypes();
            this.DropDownListMeetingType.DataBind();
        }
    }
    protected void DropDownListDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void GridViewSchedule_Sorting(object sender, GridViewSortEventArgs e)
    {
        this.fillGrid(e.SortExpression);
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        this.fillGrid(null);
    }

    private void fillGrid(String orderBy)
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        System.Collections.Generic.IList<FormattedMeetingBase> list = manager.retrieveOrderedActiveMeetingList
            (true,
            int.Parse(this.DropDownListDayOfWeek.SelectedValue),
            this.TextBoxCity.Text,
            this.DropDownListMeetingType.SelectedItem.Text.Replace(District64Constants.SELECT_ITEM, ""),  
            orderBy);

        this.GridViewSchedule.DataSource = list;
        this.GridViewSchedule.DataBind();
    }
    protected void GridViewSchedule_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
