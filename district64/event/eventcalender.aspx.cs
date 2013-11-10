using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayPilot.Web.Ui.Events;
using DayPilot.Web.Ui.Events.Bubble;

public partial class event_eventcalender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.loadControls(DateTime.Now);
        }
    }

    private void loadControls(DateTime startDate)
    {
        this.DayPilotMonthEvent.EventClickJavaScript = "window.open('/district64/event/eventdetail.aspx?id=' + e.value());";
        this.DayPilotMonthEvent.StartDate = firstDayOfWeek(startDate, DayOfWeek.Sunday);

        this.monthRefresh(startDate);
    }

    private void monthRefresh(DateTime startDate)
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;

        this.DayPilotMonthEvent.StartDate = startDate;
        this.DayPilotMonthEvent.DataSource = manager.getEventsPerCalender
            (this.DayPilotMonthEvent.StartDate.AddDays(-40), this.DayPilotMonthEvent.StartDate.AddDays(40));
        this.DayPilotMonthEvent.DataBind();;
        DayPilotMonthEvent.DataBind();
        DayPilotMonthEvent.Update();
    }

    protected void DayPilotMonthEvent_Refresh(object sender, RefreshEventArgs e)
    {
        ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager.CurrentMonth = e.StartDate;

        this.monthRefresh(e.StartDate);
    }

    private static DateTime firstDayOfWeek(DateTime day, DayOfWeek weekStarts)
    {
        DateTime d = day;
        while (d.DayOfWeek != weekStarts)
        {
            d = d.AddDays(-1);
        }

        return d;
    }


    protected void DayPilotMonthEvent_TimeRangeSelected(object sender, TimeRangeSelectedEventArgs e)
    {
      
    }

 

    protected void DayPilotMonthEvent_BeforeCellRender(object sender, DayPilot.Web.Ui.Events.Month.BeforeCellRenderEventArgs e)
    {
        if (e.Start.Day == 1)
        {
            //e.HeaderText = String.Format("<span style='font-weight: bold'>{0}</span>", e.Start.Day);
            e.HeaderText = String.Format("{0:d MMM yyyy}", e.Start);

        }
    }

    protected void DayPilotMonthEvent_BeforeEventRender(object sender, DayPilot.Web.Ui.Events.Month.BeforeEventRenderEventArgs e)
    {

    }
}
