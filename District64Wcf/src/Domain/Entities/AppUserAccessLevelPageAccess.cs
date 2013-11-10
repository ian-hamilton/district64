using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace District64.District64Wcf.Domain.Entities
{
    public class AppUserAccessLevelPageAccess
    {
        public long PageAccessId { get; set; }
        public string Page { get; set; }

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            return Page == ((AppUserAccessLevelPageAccess)obj).Page;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
