using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Xml;


public partial class rss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";
        XmlTextWriter xtwFeed = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        xtwFeed.WriteStartDocument();
        xtwFeed.WriteStartElement("rss");
        xtwFeed.WriteAttributeString("version", "2.0");
        xtwFeed.WriteStartElement("channel");
        xtwFeed.WriteElementString("title", "AA District 64");
        xtwFeed.WriteElementString("link", "http://www.district64.com");
        xtwFeed.WriteElementString("description", "The latest meeting schedule for AA District 64, NIA 20");
        xtwFeed.WriteElementString("copyright", "Copyright 2005 - 2006 www.district64.com. All rights reserved.");

        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        System.Collections.Generic.IList<FormattedMeetingBase> list = 
            manager.retrieveOrderedActiveMeetingList(true, -1, null, null, null);

        foreach (FormattedMeetingBase m in list)
        {
            xtwFeed.WriteStartElement("item");
            xtwFeed.WriteElementString("title", m.MeetingName);
            xtwFeed.WriteElementString("link", "http://www.district64.com/district64/schedule/meetingdetail.aspx?id=" + m.MeetingId.ToString());
            xtwFeed.WriteElementString("pubDate", m.RowUpdated.ToString());
            xtwFeed.WriteEndElement();
        }

        xtwFeed.WriteEndElement();
        xtwFeed.WriteEndElement();
        xtwFeed.WriteEndDocument();
        xtwFeed.Flush();
        xtwFeed.Close();
        Response.End();
    }
}
