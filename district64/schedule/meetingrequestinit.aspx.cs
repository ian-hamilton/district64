using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class schedule_meetingrequestinit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        if(this.RadioButtonListChangeType.SelectedValue.Equals("modify"))
            Server.Transfer("~/schedule/meetingchangelist.aspx");
        else if(this.RadioButtonListChangeType.SelectedValue.Equals("add"))
            Server.Transfer("~/schedule/meetingrequest.aspx?id=" + -1);
    }
}
