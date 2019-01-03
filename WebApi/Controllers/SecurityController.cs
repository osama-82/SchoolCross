using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApi.Model;
using WebApi.DataModel;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private SchoolCrossContext schoolContext;
        private readonly SignInManager<AspNetUsers> _signInManager;
        public SecurityController(SchoolCrossContext schoolContext,
                                  SignInManager<AspNetUsers> signInManager)
        {
            this.schoolContext = schoolContext;
            this._signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AppUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserId,
            user.Password,
            false,
            false);

            if (result.Succeeded)
                {
                    var d = "Abbas";
                }

            AppUserAuth returnData = new AppUserAuth();

            // var a = schoolContext.AspNetUsers.FirstOrDefault();

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