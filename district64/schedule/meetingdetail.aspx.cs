using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class schedule_meetingdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.loadControls();
    }

    private void loadControls()
    {
        ScheduleManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).ScheduleManager;

        if(Request["id"] != null)
        {
            FormattedMeetingExtended meeting = manager.retrieveMeeting(int.Parse(Request["id"]));

            this.LiteralAddress.Text = meeting.Address;
            this.LiteralCity.Text = meeting.City + ", " + meeting.State + " " + meeting.Zip;
            this.LiteralFacility.Text = meeting.Facility;
            this.LiteralHandicapp.Text = meeting.Handicapped;
            this.LiteralMeetingName.Text = meeting.MeetingName;
            this.LiteralMeetingType.Text = meeting.MeetingType;
            this.LiteralNonSmoking.Text = meeting.NonSmoking;
            this.LiteralTime.Text  = meeting.DayOfWeek + " " + meeting.TimeOfDay;
            this.LiteralWomans.Text = meeting.Womens;
          


            /* google Map settings */
            GoogleMapForASPNet1.GoogleMapObject.Width = "400px";
            GoogleMapForASPNet1.GoogleMapObject.Height = "300px";

            //get key from web config for current url
            string googleKey = ConfigurationSettings.AppSettings["googlemaps"];
            GoogleMapForASPNet1.GoogleMapObject.APIKey = googleKey;
            
            GooglePoint GP = new GooglePoint();
            //if (county.seat_city != null && county.seat_city.Trim().Length > 0)
            //    GP.Address = county.seat_address + "," + county.seat_city + "," + county.seat_state + " " + county.seat_zip + ", USA";

            GP.Address = meeting.Address + "," + meeting.City + "," + meeting.State + " " + meeting.Zip + ", USA";

            //GeocodeAddress() function will geocode address and set Latitude and Longitude of GP(GooglePoint) to it's respected value.
            if (GP.GeocodeAddress(googleKey))
            {
                //Get Latitude value in a variable
                double Latitude = GP.Latitude;
                //Get Longitude value in a variable
                double Longitude = GP.Longitude;
                GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP);
            }
        }

    }
}
