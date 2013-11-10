using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text;

/// <summary>
/// Summary description for JavasciptFactory
/// </summary>
public class JavascriptFactory
{
    public JavascriptFactory()
    { }

    public static void maxLengthMultiLine(TextBox tb, int maxSize, System.Web.UI.Page page)
    {

        string lengthFunction = "function isMaxLength(txtBox, length, e) {"
             + " if(txtBox) { "
             + " var KeyID = (window.event) ? event.keyCode : e.keyCode; "
             + " if (KeyID == 8 || KeyID == 46 || KeyID == 37 || KeyID == 39) { return true; } else { "
             + " return ( txtBox.value.length <parseInt(length));}"
             + " }"
             + "}";

        tb.Attributes.Add("onkeypress", "return isMaxLength(this," + maxSize.ToString() + ", event);");
        page.ClientScript.RegisterClientScriptBlock(
        page.GetType(),
        "txtLength",
        lengthFunction, true);

    }

    //sets the input control's onBlur (leaving textbox) and onFocus (enter textbox) events so the backcolor and forecolor can be changed
    private static void SetInputControlColors(WebControl ctrl, Color backColor, Color foreColor, Color focusBackColor, Color focusForeColor)
    {
        string jsOnFocus = string.Format("this.style.backgroundColor = '{0}';" + "this.style.color = '{1}';",
            focusBackColor.Name, focusForeColor.Name);

        string jsOnBlur = string.Format("this.style.backgroundColor = '{0}';" + "this.style.color = '{1}';",
            backColor.Name, foreColor.Name);

        ctrl.Attributes.Add("onfocus", jsOnFocus);
        ctrl.Attributes.Add("onblur", jsOnBlur);
    }

    //loops through all the controls on the webform and adds the onBlur and onFocus js events to all of the input controls 
    public static void SetAllInputControlsColors(Control parent, Color backColor, Color foreColor, Color focusBackColor, Color focusForeColor)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl is TextBox || ctrl is ListBox)
            {
                SetInputControlColors(ctrl as WebControl, backColor, foreColor, focusBackColor, focusForeColor);
            }
            else
            {
                SetAllInputControlsColors(ctrl, backColor, foreColor, focusBackColor, focusForeColor);
            }
        }
    }



    //sets focus to specified control
    public static void SetFocus(Control control)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("\r\n<script language='JavaScript'>\r\n");
        sb.Append("<!--\r\n");
        sb.Append("function SetFocus()\r\n");
        sb.Append("{\r\n");
        sb.Append("\tvar i = document.getElementsByName('");
        sb.Append(control.UniqueID);
        sb.Append("');\r\n");
        sb.Append("i[0].focus()\r\n");
        sb.Append("}\r\n");
        sb.Append("window.onload = SetFocus;\r\n");
        sb.Append("// -->\r\n");
        sb.Append("</script>");

        control.Page.RegisterClientScriptBlock("SetFocus", sb.ToString());
    }


}
