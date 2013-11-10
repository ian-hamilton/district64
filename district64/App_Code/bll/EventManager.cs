using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DistrictModel;

/// <summary>
/// Summary description for EventManager
/// </summary>
public class EventManager
{

    private DateTime _currentMonth;   

	public EventManager()
	{}


    public IList<EventCalenderItem> getEventsPerCalender(DateTime beginDate, DateTime endDate)
    {
        IList<EventCalenderItem> list = new List<EventCalenderItem>();

        using (DistrictEntities ctx = new DistrictEntities())
        {
            IQueryable<district_event> result = ctx.district_event.Where(e => e.event_date >= beginDate &&
                e.event_date <= endDate && e.status_flag == 1 && e.approved_flag == 1);

            foreach (district_event de in result)
            {
                list.Add(new EventCalenderItem(de));
            }
        }

        return list;
    }

    public EventRequest retrieveEvent(int eventId)
    {
        EventRequest request = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            district_event districtEvent = ctx.district_event.Where(e => e.event_id == eventId).First();
            request = new EventRequest(districtEvent);
        }

        return request;
    }

    public DownloadableFileInfo retreiveEventFile(int eventId)
    {
        DownloadableFileInfo dfi = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            district_event districtEvent = ctx.district_event.Where(e => e.event_id == eventId).First();
            dfi = new DownloadableFileInfo(districtEvent);
        }

        return dfi;
    }

    public EventRequest retrieveEventExtendedInfo(int eventId)
    {
        EventRequest request = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            district_event districtEvent = ctx.district_event.Where(e => e.event_id == eventId).First();
            request = new EventRequest(districtEvent);


            UserManager manager = new UserManager();

            String rowUpdated = manager.getAppUser(districtEvent.row_updated_by_user_id).app_user_name;
            String rowCreated = manager.getAppUser(districtEvent.row_created_by_user_id).app_user_name;
            String rowApproved = String.Empty;
            if (districtEvent.approved_flag.Equals(1))
                rowApproved = manager.getAppUser(districtEvent.row_approved_by_user_id.Value).app_user_name;

            request.setCreateUpdateUserName(rowCreated, rowUpdated, rowApproved);
        }


        return request;

    }

    public IList<EventRequest> retrieveEventList(Boolean onlyApproved, Boolean onlyUnapproved, Boolean onlyActive, Boolean isNotPassedDate)
    {
        return retrieveEventList(onlyApproved, onlyUnapproved, onlyActive, isNotPassedDate, null);
    }

    public IList<EventRequest> retrieveEventList(Boolean onlyApproved, Boolean onlyUnapproved, Boolean onlyActive, Boolean isNotPassedDate, DateTime? endDate)
    {
        IList<EventRequest> list = new List<EventRequest>();
        IQueryable<district_event> result = null;
        IOrderedQueryable<district_event> sortedResult = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            result = ctx.district_event;
            if (onlyApproved)
                result = result.Where(e => e.approved_flag == 1);
            if (onlyUnapproved)
                result = result.Where(e => e.approved_flag != 1);
            if (onlyActive)
                result = result.Where(e => e.status_flag == 1);
            if (isNotPassedDate)
                result = result.Where(e => e.event_date > DateTime.Now);
            if (endDate != null)
                result = result.Where(e => e.event_date <= endDate);

             sortedResult = result.OrderBy(e => e.event_date);

            foreach(district_event e in sortedResult)
            {
                list.Add(new EventRequest(e));
            }

        }
        return list;
    }

    public long addEventRequest(EventRequest transient, int userId, String uploadFileName, byte[] httpPostedFileBytes)
    {
        using (DistrictEntities ctx = new DistrictEntities())
        {
            /*
             * the following is used only to insert any 
             * uploaded files into the the database BLOB 
             * Should we only allow certain files type?
             */

            file_repository fileRepository = null;

            if (httpPostedFileBytes != null && httpPostedFileBytes.Length > 0)
            {               
                fileRepository = new file_repository();
                fileRepository.file_blob = httpPostedFileBytes;
                fileRepository.status_flag = 1;
                fileRepository.row_created = DateTime.Now;
                fileRepository.row_updated = DateTime.Now;
                fileRepository.row_created_by_user_id = userId;
                fileRepository.row_updated_by_user_id = userId;
                fileRepository.file_name = uploadFileName;
            }

            district_event newEvent = new district_event();

            if (fileRepository != null)
                newEvent.file_repository = fileRepository;

            this.fillEvent(ref newEvent, transient, userId, true);
            ctx.AddTodistrict_event(newEvent);

            int i = ctx.SaveChanges();
            return newEvent.event_id;
        }

    }

   

    public long updateEventWithApproval(EventRequest transient, int userId)
    {
        using (DistrictEntities ctx = new DistrictEntities())
        {
            district_event exist = ctx.district_event.Where(e => e.event_id == transient.EventId).First();

            this.fillEvent(ref exist, transient, userId, false);
            exist.approved_flag = 1;
            exist.row_approved = DateTime.Now;
            exist.row_approved_by_user_id = userId;

            int i = ctx.SaveChanges();
            return exist.event_id;
        }

    }

    private void fillEvent(ref district_event devent, EventRequest transient, int userId, Boolean isNew)
    {
        devent.event_subject = transient.Subject;
        devent.event_desc = transient.Desc;
        devent.event_date = transient.EventDate;
        //devent.event_begin_date = transient.EventBeginDate;
        //devent.event_stop_date = transient.EventStopDate;
        devent.event_location = transient.Location;
        devent.event_address = transient.Address;
        devent.event_city = transient.City;
        devent.event_state = transient.State;
        devent.event_zip = transient.Zip;
        devent.submitted_by = transient.Name;
        devent.submitted_by_phone = transient.Phone;
        devent.submitted_by_email = transient.Email;
        devent.status_flag = 1;
        devent.row_updated = DateTime.Now;
        devent.row_updated_by_user_id = userId;

        if (isNew)
        {
            devent.row_created = DateTime.Now;
            devent.row_created_by_user_id = userId;
        }        

    }

    public DateTime CurrentMonth
    {
        get { return _currentMonth; }
        set { _currentMonth = value; }




    }

    public EventRequest rejectRequest(long eventId, int userId)
    {
        EventRequest er = null;

        using (DistrictEntities ctx = new DistrictEntities())
        {
            district_event de = ctx.district_event.Where(e => e.event_id == eventId).First<district_event>();
                                   
            de.status_flag = 0;
            de.row_updated = DateTime.Now;
            de.row_updated_by_user_id = userId;
            ctx.SaveChanges();

            er = new EventRequest(de);
        }
        
        return er;

    }
    
}
