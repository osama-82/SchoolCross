using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApi.Model;
using WebApi.DataModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private SchoolCrossContext schoolContext;
        public SecurityController(
            SchoolCrossContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }
        [HttpPost]
        public IActionResult Post([FromBody]AppUser user)
        {
            AppUserAuth returnData = new AppUserAuth();

            var a = schoolContext.AspNetUsers.FirstOrDefault();

            returnData.UserName = "Abbas Osama";
            returnData.IsAuthenticated = true;
            returnData.BearerToken = "eyJhbGciOiJIUzI1NiIs";
            returnData.Claims = new List<AppUserClaim>();
            AppUserClaim cliam = new AppUserClaim();
            cliam.ClaimId = new Guid();
            cliam.ClaimType = "CanAccessProducts";
            cliam.ClaimValue = "true";
            returnData.Claims.Add(cliam);
            return StatusCode(StatusCodes.Status200OK, returnData);
        }
    }
}