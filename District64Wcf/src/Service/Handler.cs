using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using District64.District64Wcf.Domain.Entities;

namespace District64.District64Wcf.Service
{
    public delegate void VoidDelegate();
    public delegate object ObjectDelegate(); 

    public static class Handler<T>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Handler<T>));

        public static void WithTryCatch(VoidDelegate v)
        {
            try
            {
                v();
            }
            catch (Exception ex)
            {
                _log.Error("Handler Exception", ex);
                throw;
            }
        }

        public static T WithTryCatch(ObjectDelegate v)
        {
            try
            {
                return (T)v();
            }
            catch (Exception ex)
            {
                _log.Error("Handler Exception", ex);
                throw;
            }
        }

    }
}