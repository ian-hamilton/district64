using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistrictModel;

/// <summary>
/// Summary description for FormattedMeetingExtended
/// </summary>
public class FormattedMeetingExtended : FormattedMeetingBase
{
    protected String _facility;
    protected String _note;
    protected String _address;
    protected String _state;
    protected String _zip;
    protected String _districtNumber;
    protected String _nonSmoking;
    protected String _handicapped;
    protected String _womens; 

	public FormattedMeetingExtended(meeting m) : base(m)
	{
        this._facility = m.facility;
        this._note = m.note;
        this._address = m.address;
        this._state = m.state;
        this._districtNumber = m.district_number.ToString();
        if (m.non_smoking_flag == 0)
            this._nonSmoking = "No";
        else
            this._nonSmoking = "Yes";
        if (m.handicapped_flag == 0)
            this._handicapped = "No";
        else
            this._handicapped = "Yes";
        if (m.womens_flag == 0)
            this._womens = "No";
        else
            this._womens = "Yes";
    }

    public String Womens
    {
        get { return _womens; }
    }

    public String Handicapped
    {
        get { return _handicapped; }
    }

    public String NonSmoking
    {
        get { return _nonSmoking; }
    }

    public String DistrictNumber
    {
        get { return _districtNumber; }
    }

    public String Zip
    {
        get { return _zip; }
    }

    public String State
    {
        get { return _state; }
    }

    public String Address
    {
        get { return _address; }
    }

    public String Note
    {
        get { return _note; }
    }

    public String Facility
    {
        get { return _facility; }
    }
}
