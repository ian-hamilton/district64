using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SessionManager manager = (SessionManager)Session[SessionManager.SESSION_MANAGER];
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            IList<EventRequest> list = CacheWrapper.getLatestEventsCache(Cache, manager.EventManager);

            if (list.Count > 0)
            {               
                builder.Append("<ul class=\"article-zebra-list\">");

                foreach (EventRequest er in list)
                {
                    builder.Append("<li>" + er.EventDate.ToShortDateString() + ": <a href=\"/district64/event/eventdetail.aspx?id=" + er.EventId + "\">"
                        + er.Subject + "</a></li>");

                }

                builder.Append("</ul>");
            }
            else
            {
                builder.Append("<b>No Upcoming Events </b>");

            }               
           
            this.LiteralEvents.Text = builder.ToString();

        }
    }
}
