using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApi.DataModel
{
    public partial class AspNetUserLogins : IdentityUserLogin<string>
    {
        // public string LoginProvider { get; set; }
        // public string ProviderKey { get; set; }
        // public string UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
