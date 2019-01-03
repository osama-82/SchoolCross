using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace WebApi.DataModel
{
    public partial class AspNetUserClaims : IdentityUserClaim<string>
    {
        // public int Id { get; set; }
        // public string UserId { get; set; }
        // public string ClaimType { get; set; }
        // public string ClaimValue { get; set; }

        public AspNetUsers User { get; set; }
    }
}
