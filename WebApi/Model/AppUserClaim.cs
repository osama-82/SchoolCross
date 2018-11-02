using System;

namespace WebApi.Model
{
    public class AppUserClaim
    {
        public Guid ClaimId { get; set; }

        public Guid UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

    }
}