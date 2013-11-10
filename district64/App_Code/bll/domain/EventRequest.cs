using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistrictModel;

/// <summary>
/// Summary description for EventRequest
/// </summary>
public class EventRequest
{
    private long _eventId;
    private String _subject;
    private String _desc;
    private DateTime _eventDate;
    private DateTime _eventStopDate;
    private String _location;
    private String _address;
    private String _city;
    private String _state;
    private String _zip;
    private String _name;
    private String _phone;
    private String _email;
    private String _approvedByDate;
    private String _updatedByDate;
    private String _createdByDate;
    private int _approved;  
    private int _status;

    private Byte[] _file;



    public EventRequest(district_event e)
    {
        this._eventId = e.event_id;
        this._subject = e.event_subject;
        this._desc = e.event_desc;
        this._eventDate = e.event_date;
        this._location = e.event_location;
        this._address = e.event_address;
        this._city = e.event_city;
        this._state = e.event_state;
        this._zip = e.event_zip;
        this._name = e.submitted_by;
        this._phone = e.submitted_by_phone;
        this._email = e.submitted_by_email;
        if (e.approved_flag.Equals(1) && e.row_approved.HasValue)
            this._approvedByDate = e.row_approved.Value.ToShortDateString() + " " + e.row_approved.Value.ToShortTimeString();
        this._createdByDate = e.row_created.ToShortDateString() + " " + e.row_created.ToShortTimeString();
        this._updatedByDate = e.row_updated.ToShortDateString() + " " + e.row_updated.ToShortTimeString();
        this._status = e.status_flag; 
        this._approved = e.approved_flag;
    }

    public EventRequest()
    { }

    public void setCreateUpdateUserName(String rowCreateBy, String rowUpdateBy, String approvedBy)
    {
        this._createdByDate = this._createdByDate + " " + rowCreateBy;
        this._updatedByDate = this._updatedByDate + " " + rowUpdateBy;
        if(this._approvedByDate != null && this._approvedByDate.Length > 0)
            this._approvedByDate = this._approvedByDate + " " + approvedBy;

    }

    public long EventId
    {
        get { return _eventId; }
        set { _eventId = value; }
    }
    public String Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public String Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

    public String Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public String Zip
    {
        get { return _zip; }
        set { _zip = value; }
    }

    public String State
    {
        get { return _state; }
        set { _state = value; }
    }

    public String City
    {
        get { return _city; }
        set { _city = value; }
    }

    public String Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public String Location
    {
        get { return _location; }
        set { _location = value; }
    }

    public DateTime EventDate
    {
        get { return _eventDate; }
        set { _eventDate = value; }
    }

    //public DateTime EventBeginDate
    //{
    //    get { return _eventBeginDate; }
    //    set { _eventBeginDate = value; }
    //}

    public DateTime EventStopDate
    {
        get { return _eventStopDate; }
        set { _eventStopDate = value; }
    }

    public String Desc
    {
        get { return _desc; }
        set { _desc = value; }
    }

    public String Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }
    public int Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public String CreatedByDate
    {
        get { return _createdByDate; }
        set { _createdByDate = value; }
    }

    public String UpdatedByDate
    {
        get { return _updatedByDate; }
        set { _updatedByDate = value; }
    }

    public String ApprovedByDate
    {
        get { return _approvedByDate; }
        set { _approvedByDate = value; }
    }

    public Byte[] File
    {
        get { return _file; }
        set { _file = value; }
    }
    public int Approved
    {
        get { return _approved; }
        set { _approved = value; }
    }
}
