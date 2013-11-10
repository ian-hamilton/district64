using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class event_eventdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            this.loadControls();
    }

    private void loadControls()
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;

        if (Request["success"] != null)
            this.MultiViewSuccess.SetActiveView(this.ViewSuccessMessage);
        {
            EventRequest eventRequest = manager.retrieveEvent(int.Parse(Request["id"]));
            this.LiteralAddress.Text = eventRequest.Address;
            this.LiteralCity.Text = eventRequest.City + ", " + eventRequest.State + " " + eventRequest.Zip;
            this.LiteralDate.Text = eventRequest.EventDate.ToLongDateString() + " " + eventRequest.EventDate.ToShortTimeString();
            this.LiteralDesc.Text = eventRequest.Desc;
            this.LiteralLocation.Text = eventRequest.Location;
            this.LiteralSubject.Text = eventRequest.Subject;

            /* google Map settings */
            GoogleMapForASPNet1.GoogleMapObject.Width = "400px";
            GoogleMapForASPNet1.GoogleMapObject.Height = "300px";

            //get key from web config for current url
            string googleKey = ConfigurationSettings.AppSettings["googlemaps"];
            GoogleMapForASPNet1.GoogleMapObject.APIKey = googleKey;

            GooglePoint GP = new GooglePoint();
            //if (county.seat_city != null && county.seat_city.Trim().Length > 0)
            //    GP.Address = county.seat_address + "," + county.seat_city + "," + county.seat_state + " " + county.seat_zip + ", USA";

            GP.Address = eventRequest.Address + "," + eventRequest.City + "," + eventRequest.State + " " + eventRequest.Zip + ", USA";

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
    protected void LinkButtonFlyer_Click(object sender, EventArgs e)
    {
        EventManager manager = ((SessionManager)Session[SessionManager.SESSION_MANAGER]).EventManager;
        DownloadableFileInfo dfi = manager.retreiveEventFile(int.Parse(Request["id"]));

        if (dfi.HasFile)
        {
            Response.AddHeader("Content-Disposition", "attachment;filename=" + dfi.FileName);
            Response.ContentType = dfi.parseApplicationType();

            Response.BinaryWrite(dfi.FileByteArray);
        }
        else
        {
            this.LiteralFlyer.Text = "Sorry...Downloadable Flyer is not available for this event";
        }
    }
}
