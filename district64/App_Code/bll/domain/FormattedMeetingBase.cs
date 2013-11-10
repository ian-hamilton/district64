using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistrictModel;

/// <summary>
/// Summary description for FormattedMeetingBase
/// </summary>
public class FormattedMeetingBase
{
    protected long _meetingId;
    protected String _dayOfWeek;
    protected String _timeOfDay;
    protected String _meetingName;
    protected String _city;
    protected String _meetingType;
    private long _meetingChangeRequestId;
    private DateTime _rowCreated;
    private DateTime _rowUpdated;


	public FormattedMeetingBase(meeting m)
	{
        this._meetingId = m.meeting_id;
        this._dayOfWeek = System.Globalization.CultureInfo.
            CurrentCulture.DateTimeFormat.DayNames[m.day_of_week - 1].ToString();

        this._timeOfDay = m.time_of_day + " " + m.modulation;
        this._meetingName = m.meeting_name;
        this._city = m.city;
        this._meetingType = m.meeting_type;
        this.RowCreated = m.row_created;
        this.RowUpdated = m.row_updated;
    
    }

    public FormattedMeetingBase(meeting_change_request m)
    {
        this._meetingChangeRequestId = m.meeting_change_request_id;

        if(m.meeting_id != null)
            this._meetingId = m.meeting_id.Value;
        this._dayOfWeek = System.Globalization.CultureInfo.
            CurrentCulture.DateTimeFormat.DayNames[m.day_of_week - 1].ToString();

        this._timeOfDay = m.time_of_day + " " + m.modulation;
        this._meetingName = m.meeting_name;
        this._city = m.city;
        this._meetingType = m.meeting_type;

        this._rowCreated = m.row_created;

    }

    public long MeetingId
    {
        get { return _meetingId; }
    }
    public String DayOfWeek
    {
        get { return _dayOfWeek; }
    }
    public String MeetingName
    {
        get { return _meetingName; }
    }
    public String City
    {
        get { return _city; }
    }
    public String MeetingType
    {
        get { return _meetingType; }
    }
    public String TimeOfDay
    {
        get { return _timeOfDay; }
    }
    
    public long MeetingChangeRequestId
    {
        get { return _meetingChangeRequestId; }
        set { _meetingChangeRequestId = value; }
    }

    public DateTime RowCreated
    {
        get { return _rowCreated; }
        set { _rowCreated = value; }
    }

    public DateTime RowUpdated
    {
        get { return _rowUpdated; }
        set { _rowUpdated = value; }
    }

}
