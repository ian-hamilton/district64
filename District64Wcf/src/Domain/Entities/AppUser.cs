using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace District64.District64Wcf.Domain.Entities
{
    public class AppUser
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsValid { get; set; }

        public AppUserAccessLevel AccessLevel { get; set; }
    }
}
