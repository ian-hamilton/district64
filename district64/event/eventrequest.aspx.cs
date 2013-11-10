using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistrictModel;


public partial class event_eventrequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JavascriptFactory.maxLengthMultiLine(this.TextBoxEventDesc, 2000, this);
        if (!IsPostBack) 
        { 
            if(Request["id"] != null)
                loadControls(int.Parse(Request["id"])); //convert id which is string to integer
            else
                loadControls(-1); 
        }
    }
    private void loadControls(int eventId)
    {
        this.DropDownListState.DataSource = District64Constants.states;
        this.DropDownListState.DataBind();
        this.DropDownListState.SelectedItem.Text = "IL";

        if (eventId > 0)
        {
            this.MultiViewEvent.SetActiveView(this.ViewExtendedInfo);
            this.ButtonSubmit.Text = "Change and Approve";

            EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;
            EventRequest request = manager.retrieveEventExtendedInfo(eventId);

            this.LiteralEventId.Text = request.EventId.ToString();
            this.LiteralCreated.Text = request.CreatedByDate;
            this.LiteralUpdated.Text = request.UpdatedByDate;
            this.LiteralApproved.Text = request.ApprovedByDate;

            if (!request.Status.Equals(1))
            {
                this.LiteralStatus.Text = "Rejected";
            }
            else
            {
                if (request.Approved.Equals(1))
                    this.LiteralStatus.Text = "Approved";
                else
                    this.LiteralStatus.Text = "Unapproved";

            }
           

            this.TextBoxSubject.Text = request.Subject;
            this.TextBoxEventDesc.Text = request.Desc;
            this.TextBoxEventDate.Text = request.EventDate.ToShortDateString();

            if (request.EventDate.TimeOfDay.CompareTo(new TimeSpan(12, 0, 0)) == 1)
                this.TextBoxModulation.Text = "PM";
            else
                this.TextBoxModulation.Text = "AM";
            if (request.EventDate.TimeOfDay.Hours > 12)
                this.TextBoxHour.Text = (request.EventDate.TimeOfDay.Hours - 12).ToString();
            else
                this.TextBoxHour.Text = request.EventDate.TimeOfDay.Hours.ToString();
            this.TextBoxMinute.Text = request.EventDate.TimeOfDay.Minutes.ToString();

            this.TextBoxLocation.Text = request.Location;
            this.TextBoxAdress.Text = request.Address;
            this.TextBoxCity.Text = request.City;
            this.DropDownListState.SelectedItem.Text = request.State;
            this.TextBoxZip.Text = request.Zip;
            this.TextBoxSubmittedBy.Text = request.Name;
            this.TextBoxSubmittedPhone.Text = request.Phone;
            this.TextBoxEmail.Text = request.Email;

            this.FileUploadFlyer.Visible = false;
            this.LinkButtonFlyer.Visible = true;
            this.ButtonReject.Visible = true;
        }
        else
        {
            this.FileUploadFlyer.Visible = true;
            this.LinkButtonFlyer.Visible = false;
            this.ButtonReject.Visible = false;
        }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;
        app_user user = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).LoginUser;

        EventRequest er = new EventRequest();

        if (Request["id"] != null)
            er.EventId = int.Parse(Request["id"]);

        er.Subject = this.TextBoxSubject.Text.Trim();
        er.Desc = this.TextBoxEventDesc.Text.Trim();

        String dateString = this.TextBoxEventDate.Text.Trim();
        dateString += " " + this.TextBoxHour.Text + ":" + this.TextBoxMinute.Text + ":00" + " " + this.TextBoxModulation.Text;
        er.EventDate = DateTime.Parse(dateString);

        er.Location = this.TextBoxLocation.Text.Trim();
        er.Address = this.TextBoxAdress.Text.Trim();
        er.City = this.TextBoxCity.Text.Trim();
        er.State = this.DropDownListState.SelectedItem.Text;
        er.Zip = this.TextBoxZip.Text.Trim();
        er.Name = this.TextBoxSubmittedBy.Text.Trim();
        er.Phone = this.TextBoxSubmittedPhone.Text.Trim().Replace("-", "");
        er.Email = this.TextBoxEmail.Text.Trim();

        long id = 0;
        if (er.EventId > 0)
        {
            id = manager.updateEventWithApproval(er, (int)user.user_id);
            Server.Transfer("~/event/eventrequest.aspx?id=" + id.ToString());
        }
        else
        {
            String name = null;
            byte[] byteArray = null;
            if (this.FileUploadFlyer.FileName != null && this.FileUploadFlyer.FileName.Trim().Length > 0)
            {
                name = this.FileUploadFlyer.FileName;
                HttpPostedFile httpPostedFile = this.FileUploadFlyer.PostedFile;
                byteArray = new byte[httpPostedFile.ContentLength];
                httpPostedFile.InputStream.Read(byteArray, 0, httpPostedFile.ContentLength);
            }

            id = manager.addEventRequest(er, (int)user.user_id, name, byteArray);
            Server.Transfer("~/event/eventdetail.aspx?id=" + id.ToString() + "&success=true");
        }
    }

    private void serverSideValidate()
    {
        
    }
    protected void LinkButtonFlyer_Click(object sender, EventArgs e)
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;
        DownloadableFileInfo dfi = manager.retreiveEventFile(int.Parse(Request["id"]));

        Response.AddHeader("Content-Disposition", "attachment;filename=" + dfi.FileName);
        Response.ContentType = dfi.parseApplicationType();

        Response.BinaryWrite(dfi.FileByteArray);
    }

    protected void ButtonReject_Click(object sender, EventArgs e)
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;
        long userId = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).LoginUser.user_id;
               
        EventRequest m = manager.rejectRequest(long.Parse(Request["id"]), (int)userId);

        this.loadControls((int)m.EventId);
    }
    
}
