using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApi.DataModel
{
    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            PraiseComplaints = new HashSet<PraiseComplaints>();
        }
        public DateTime? LockoutEndDateUtc { get; set; }
        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ICollection<PraiseComplaints> PraiseComplaints { get; set; }
    }
}
