using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistrictModel;


public class ScheduleManager
{

    public IList<String> retreiveDistinctTypes()
    {
        IList<String> list = new List<String>();

        using (DistrictEntities ctx = new DistrictEntities())
        {

            var result = ctx.meeting.Select(m => m.meeting_type).Distinct();

            list.Add(District64Constants.SELECT_ITEM);
            foreach ( var t in result )   
            {
                list.Add(t.ToString());
            }
        }

        return list;
    }

    public IList<FormattedMeetingBase> retrieveOrderedActiveMeetingList(Boolean isActiveOnly, 
        int dayOfWeek, String city, String meetingType, String orderBy)
    {
        IList<FormattedMeetingBase> list = new List<FormattedMeetingBase>();
        IQueryable<meeting> result = null;
        IOrderedQueryable<meeting> sortedResult = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            result = ctx.meeting.Where(m => m.status_flag == 1);                
            if(dayOfWeek != -1)
                result = result.Where(m => m.day_of_week == dayOfWeek);
            if(city != null && city.Length > 0)
                result = result.Where(m => m.city.ToLower() == city.Trim().ToLower());
            if (meetingType != null && meetingType.Length > 0)
                result = result.Where(m => m.meeting_type == meetingType);

            if (orderBy == null || orderBy.Length == 0)
                sortedResult = result.OrderBy(m => m.time_of_day).OrderBy(m => m.day_of_week);
            else if (orderBy.Equals("meetingName"))
                sortedResult = result.OrderBy(m => m.meeting_name);
            else if (orderBy.Equals("dayOfWeek"))
                sortedResult = result.OrderBy(m => m.day_of_week);
            else if (orderBy.Equals("timeOfDay"))
                sortedResult = result.OrderBy(m => m.military_time);
            else if (orderBy.Equals("city"))
                sortedResult = result.OrderBy(m => m.city);
            else if (orderBy.Equals("type"))
                sortedResult = result.OrderBy(m => m.meeting_type);

            

            foreach (meeting m in sortedResult)
            {
                list.Add(new FormattedMeetingBase(m));
            }

        }

        return list;
    }

    public IList<FormattedMeetingBase> retrieveOrderedApprovalNeededList()
    {
        IList<FormattedMeetingBase> list = new List<FormattedMeetingBase>();
        IOrderedQueryable<meeting_change_request> result = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            result = ctx.meeting_change_request.Where(m => m.status_flag == 1).OrderBy(m=> m.row_created);

            foreach (meeting_change_request m in result)
            {
                list.Add(new FormattedMeetingBase(m));
            }

        }

        return list;
    }

    public FormattedMeetingExtended retrieveMeeting(int meetingId)
    {
        FormattedMeetingExtended fmeeting = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            meeting meet = ctx.meeting.Where(m => m.meeting_id == meetingId).First<meeting>();
            fmeeting = new FormattedMeetingExtended(meet);
        }

        return fmeeting;
    }

    public meeting retrieveRawMeeting(int meetingId)
    {
        meeting meet = null;
        using (DistrictEntities ctx = new DistrictEntities())
        {
            meet = ctx.meeting.Where(m => m.meeting_id == meetingId).First<meeting>();
            
        }

        return meet;
    }

    /** the following function will deal with the meeting request */
    public meeting_change_request retreiveRawMeetingChangeRequest(int meetingChangeRequestId)
    {
        meeting_change_request mcr = null;
        using (DistrictEntities ctx = new DistrictEntities())
        {
            mcr = ctx.meeting_change_request.Where(m => m.meeting_change_request_id == meetingChangeRequestId).First<meeting_change_request>();
        }

        return mcr;
    }
    public long addMeetingRequest(meeting_change_request transient, int userId)
    {
        using (DistrictEntities ctx = new DistrictEntities())
        {
            transient.row_created_by_user_id = userId;
            transient.row_updated_by_user_id = userId;
            transient.row_created = DateTime.Now;
            transient.row_updated = DateTime.Now;

            ctx.AddTomeeting_change_request(transient);
            int i = ctx.SaveChanges();
        }

        return transient.meeting_change_request_id;
    }

    public meeting_change_request updateMeetingWithRequest(meeting_change_request transient, int userId)
    {
        meeting_change_request mcr = null;
        meeting m = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            mcr = ctx.meeting_change_request.Where(mcr2 => mcr2.meeting_change_request_id == transient.meeting_change_request_id).First<meeting_change_request>();

            mcr.row_updated = DateTime.Now;
            mcr.approved = DateTime.Now;
            mcr.approved_flag = 1;

            mcr.row_updated_by_user_id = userId;
            mcr.row_updated = DateTime.Now;
            mcr.address = transient.address;
            mcr.city = transient.city;
            mcr.day_of_week = transient.day_of_week;
            mcr.district_number = transient.district_number;
            mcr.facility = transient.facility;
            mcr.handicapped_flag = transient.handicapped_flag;
            mcr.meeting_name = transient.meeting_name;
            mcr.meeting_type = transient.meeting_type;
            mcr.military_time = transient.military_time;
            mcr.modulation = transient.modulation;
            mcr.non_smoking_flag = transient.non_smoking_flag;
            mcr.note = transient.note;
            mcr.state = transient.state;
            mcr.time_of_day = transient.time_of_day;
            mcr.womens_flag = transient.womens_flag;
            mcr.zip = transient.zip;

            ctx.SaveChanges();

            if (mcr.meeting_id == null)
            {
                m = new meeting();
                m.row_created = DateTime.Now;
                m.row_created_by_user_id = userId;
                ctx.AddTomeeting(m);
            }
            else
            {
                m = ctx.meeting.Where(mm => mm.meeting_id == mcr.meeting_id).First<meeting>();
            }                       

            m.row_updated_by_user_id = userId;
            m.row_updated = DateTime.Now;
            m.address = mcr.address;
            m.city = mcr.city;
            m.day_of_week = mcr.day_of_week;
            m.district_number = mcr.district_number;
            m.facility = mcr.facility;
            m.handicapped_flag = mcr.handicapped_flag;
            m.meeting_name = mcr.meeting_name;
            m.meeting_type = mcr.meeting_type;
            m.military_time = mcr.military_time;
            m.modulation = mcr.modulation;
            m.non_smoking_flag = mcr.non_smoking_flag;
            m.note = mcr.note;
            m.state = mcr.state;
            m.time_of_day = mcr.time_of_day;
            m.womens_flag = mcr.womens_flag;
            m.zip = mcr.zip;
            m.status_flag = 1;

            ctx.SaveChanges();

            mcr.meeting_id = m.meeting_id;
            mcr.status_flag = 0;
            ctx.SaveChanges();
        }

        return mcr;

    }

    public meeting_change_request rejectRequest(long meetingChangeRequestId, int userId)
    {
        meeting_change_request mcr = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            mcr = ctx.meeting_change_request.Where(m => m.meeting_change_request_id == meetingChangeRequestId).First<meeting_change_request>();

            mcr.status_flag = 0;
            mcr.row_updated = DateTime.Now;
            mcr.row_updated_by_user_id = userId;
            ctx.SaveChanges();
        }
        return mcr;

    }
}
