using System.Collections.Generic;

namespace WebApi.Model
{
    public class AppUserAuth
    {
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<AppUserClaim> Claims { get; set; }
    }
}