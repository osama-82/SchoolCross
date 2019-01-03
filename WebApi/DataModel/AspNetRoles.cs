using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApi.DataModel
{
    public partial class AspNetRoles : IdentityRole
    {
        public AspNetRoles()
        {
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        // public string Id { get; set; }
        // public string Name { get; set; }

        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
