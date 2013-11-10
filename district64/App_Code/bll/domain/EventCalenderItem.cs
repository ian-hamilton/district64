using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistrictModel;

/// <summary>
/// Summary description for EventCalenderItem
/// </summary>
public class EventCalenderItem
{
    private long _id;
    private String _name;
    private DateTime _start;
    private DateTime _end;

	public EventCalenderItem(district_event e)
	{
        this._id = e.event_id;
        this._name = e.event_subject;
        this._start = e.event_date;
        this._end = e.event_date.AddHours(1); 
    }

    public long id
    {
        get { return _id; }
        set { _id = value; }
    }
    public String name
    {
        get { return _name; }
        set { _name = value; }
    }
    public DateTime start
    {
        get { return _start; }
        set { _start = value; }
    }
    public DateTime end
    {
        get { return _end; }
        set { _end = value; }
    }
}
