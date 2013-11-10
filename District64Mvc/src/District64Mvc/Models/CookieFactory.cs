using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace District64.District64Mvc.Models
{
    /// <summary>
    /// Class used to write cookies to 
    /// to provied domain or to the default domain
    /// </summary>
    public class CookieFactory
    {
        private string _domain;

        public CookieFactory() { }

        public CookieFactory(string domain)
        {
            _domain = domain;
        }

        /// <summary>
        /// Generates Cookie based with provided name and value
        /// </summary>
        /// <param name="name">The name of the cookie</param>
        /// <param name="value">The value of the cookie, if null will set the cookie to expire</param>
        /// <returns>The instantiated Http Cookie</returns>
        public  HttpCookie GenerateCookie(string name, object value)
        {
            return new HttpCookie(name, value != null ? value.ToString() : null)
                {
                    Expires = value != null ? DateTime.MaxValue : DateTime.Now.AddDays(-1),
                   // Domain = _domain,
                    Secure = false,
                    HttpOnly = true
                };
        }

        /// <summary>
        /// Reads cookies and transforms them into Int32
        /// </summary>
        /// <param name="name">The name of the cookie to read, if exists</param>
        /// <param name="request">the Http Request that contains the cookie header</param>
        /// <returns>The read Int32 value or null</returns>
        public int? ReadInt32Cookie(string name, HttpRequestBase request)
        {
            return request.Cookies[name] != null ?  Int32.Parse(request[name]) : (int?)null;            
        }

        /// <summary>
        /// Reads cookies and transforms them into Int32
        /// </summary>
        /// <param name="name">The name of the cookie to read, if exists</param>
        /// <param name="request">the Http Request that contains the cookie header</param>
        /// <returns>The read String value of Empty</returns>
        public string ReadCookie(string name, HttpRequestBase request)
        {
            return request.Cookies[name] != null ? request[name] : String.Empty;
        }
    }
}