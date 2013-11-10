using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using DistrictModel;


public static class CacheWrapper
{
    private const String CACHE_LATEST_EVENT = "latestevents";
    private const String CACHE_PAGES = "pages";


    public static IList<EventRequest> getLatestEventsCache(Cache cache, EventManager manager)
    {
        if(cache[CACHE_LATEST_EVENT] == null)
        {
            IList<EventRequest> list = manager.retrieveEventList
                (true, false, true, true, DateTime.Now.AddMonths(3));

            cache.Insert(CACHE_LATEST_EVENT, list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0));

        }

        return (IList<EventRequest>)cache[CACHE_LATEST_EVENT];
    }

    public static Int32? getPageAccessLevelCache(Cache cache, UserManager manager, String pageName)
    {
        if (cache[CACHE_PAGES] == null)
        {
            IList<page_access> list = manager.getPageAccess();
            IDictionary<String, Int32> d = new Dictionary<String, Int32>();
            foreach (page_access pa in list)
            {
                d.Add(pa.page.ToLower(), pa.access_level.access_level_id);
            }

            cache.Insert(CACHE_PAGES, d, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(12, 0, 0));
        }

        Int32? returnval = null;
        IDictionary<String, Int32> dictionary = (IDictionary<String, Int32>)cache[CACHE_PAGES];
        if(dictionary.ContainsKey(pageName))
            returnval = dictionary[pageName.ToLower()];

        return returnval;
    }
}
