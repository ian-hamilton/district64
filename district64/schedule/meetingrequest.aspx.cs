using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DistrictModel;

public partial class schedule_meetingrequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        


        if (!IsPostBack)
        {
            if (Request["id"] != null)
                loadControls(int.Parse(Request["id"]));
            else
                loadControls(-1); 
        }
    }


    private void loadControls(int meetingId)
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        this.DropDownListMeetingType.DataSource = manager.retreiveDistinctTypes();
        this.DropDownListMeetingType.DataBind();

        this.DropDownListState.DataSource = District64Constants.states;
        this.DropDownListState.DataBind();
        this.DropDownListState.SelectedItem.Text = "IL";

        if (meetingId >= 0)
        {
            meeting m = manager.retrieveRawMeeting(meetingId);

            this.TextBoxMeetingName.Text = m.meeting_name;
            this.DropDownListMeetingType.SelectedValue = m.meeting_type;
            this.DropDownListDayOfWeek.SelectedValue = m.day_of_week.ToString();
            this.TextBoxHour.Text = m.time_of_day.Substring(0, m.time_of_day.IndexOf(':'));
            this.TextBoxMinute.Text = m.time_of_day.Substring(m.time_of_day.IndexOf(':') + 1, 2);
            this.TextBoxModulation.Text = m.modulation;
            this.TextBoxFacility.Text = m.facility;
            this.TextBoxNote.Text = m.note;
            this.TextBoxCity.Text = m.city;
            this.TextBoxAddress.Text = m.address;
            this.DropDownListState.SelectedValue = m.state;
            this.TextBoxZip.Text = m.zip;
            if(m.district_number != null)
                this.TextBoxDistrictNumber.Text = m.district_number.ToString();
            if (m.womens_flag.Equals(1))
                this.CheckBoxWomens.Checked = true;
            if (m.handicapped_flag.Equals(1))
                this.CheckBoxHandicapped.Checked = true;

        }

    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        meeting_change_request m = new meeting_change_request();

        if(Request["id"] != null)
            m.meeting_id = int.Parse(Request["id"]);

        long userId = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).LoginUser.user_id;

        m.meeting_change_request_id = 0;
        m.meeting_name = this.TextBoxMeetingName.Text.Trim();
        m.meeting_type = this.DropDownListMeetingType.SelectedValue;
        m.day_of_week = int.Parse(this.DropDownListDayOfWeek.SelectedValue);
        m.time_of_day = this.TextBoxHour.Text + ":" + this.TextBoxMinute.Text;
        m.modulation = this.TextBoxModulation.Text;
        m.facility = this.TextBoxFacility.Text.Trim();
        m.note = this.TextBoxNote.Text.Trim();
        m.address = this.TextBoxAddress.Text.Trim();
        m.city = this.TextBoxCity.Text.Trim();
        m.state = this.DropDownListState.SelectedValue;
        m.zip = this.TextBoxZip.Text.Trim();
        if (this.TextBoxDistrictNumber.Text.Trim().Length > 0)
            m.district_number = int.Parse(this.TextBoxDistrictNumber.Text.Trim());

        m.requestor = this.TextBoxSubmittedBy.Text.Trim();
        m.requestor_email = this.TextBoxEmail.Text.Trim();
        m.requestor_phone = this.TextBoxSubmittedPhone.Text.Trim();
        if (this.CheckBoxGsr.Checked) m.gsr_flag = 1; else m.gsr_flag = 0;
        if (this.CheckBoxHandicapped.Checked) m.handicapped_flag = 1; else m.handicapped_flag = 0;
        if (this.CheckBoxWomens.Checked) m.womens_flag = 1; else m.womens_flag = 0;

        if (this.TextBoxHour.Text.Trim().Equals("12") && this.TextBoxModulation.Text.Trim().Equals("PM"))
            m.military_time = "00:" + this.TextBoxMinute.Text.Trim();
        else if (this.TextBoxHour.Text.Trim().Equals("12") && this.TextBoxModulation.Text.Trim().Equals("PM"))
            m.military_time = "12:" + this.TextBoxMinute.Text.Trim();
        else if (this.TextBoxModulation.Text.Trim().Equals("PM"))
            m.military_time = (int.Parse(this.TextBoxHour.Text.Trim()) + 12).ToString() + ":" + this.TextBoxMinute.Text;
        else
            m.military_time = this.TextBoxHour.Text.PadLeft(2, '0') + ":" + this.TextBoxMinute.Text;

        m.status_flag = 1;
        manager.addMeetingRequest(m, (int)userId);

        Server.Transfer("~/schedule/meetingrequestsuccess.aspx");
    }
}
