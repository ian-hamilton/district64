using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace District64.District64Wcf.Domain.Entities
{
    public class AppUserAccessLevel
    {
        public int AccessLevelId { get; set; }
        public string AccessLevelDesc { get; set; }

        public List<AppUserAccessLevelPageAccess> AllowedPages { get; set; }
    }
}
