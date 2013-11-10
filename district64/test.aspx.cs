using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserManager m = new UserManager();
        bool b = m.isUser(this.TextBox1.Text);

        if (b)
        {
            DistrictModel.app_user user = m.getAppUser(this.TextBox1.Text);

            this.Literal1.Text = "Name = " + user.user_first_name + " " + user.user_last_name;

            bool test = m.checkPageAccessAgainstUser(WebHelper.GetCurrentPageName(), user);
            if (test)
                LiteralAuthor.Text = "Authorized";
            else
                LiteralAuthor.Text = "Unauthorized";

        }
        else
        {
            this.Literal1.Text = b.ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
}
