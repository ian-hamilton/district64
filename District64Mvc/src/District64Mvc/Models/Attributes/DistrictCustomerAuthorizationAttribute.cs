using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using District64.District64Mvc.Models;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Mvc.Models.Attributes
{
    public class DistrictCustomerAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string userId;
            if (httpContext.Request.IsLocal)
                userId = "2";
            else
                userId = new CookieFactory().ReadCookie(District64MvcConstants.COOKIE_NAME_USER, httpContext.Request);

            string route = httpContext.Request.RawUrl.ToString();

            IDistrictService service = new DistrictServiceClient();
            return service.HasPageOrRouteAccess(Int64.Parse(userId), route);

            return true;
        }
    }
}