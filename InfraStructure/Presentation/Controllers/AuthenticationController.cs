using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DaraTransferObject.IdentityDtos;
using Shared.DaraTransferObject.IdentiyDto;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class AuthenticationController(IServiceManager _serviceManager) : ControllerBase
    {



        [HttpPost("Login")]
        //Login  //post baseurl//api/Authentication//login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var User= await _serviceManager.AuthentacationService.LoginAsync(loginDto);


            return Ok(User);

        }


        //Register       //post baseurl//api/Authentication//Register
        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var User = await _serviceManager.AuthentacationService.RegisterAsync(registerDto);


            return Ok(User);

        }

        //CheckEmail     //Get baseurl//api/Authentication//CheckEmail
        [HttpGet("CheckEmail")]

        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var Result = await _serviceManager.AuthentacationService.CheckEmailAsync(email);


            return Ok(Result);

        }


        //CheckEmail     //Get baseurl//api/Authentication//CheckEmail

        [Authorize]
        [HttpGet("CurrentUser")]

        public async Task<ActionResult<UserDto>> GetCurrentUser( )
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var Appuser= await _serviceManager.AuthentacationService.GetCurrentUserAsync(email!);







            return Ok(Appuser);

        }

        [Authorize]
        [HttpGet("Address")]

        public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var Address = await _serviceManager.AuthentacationService.GetAddressAsync(email!);







            return Ok(Address);

        }


        [Authorize]
        [HttpPut("Address")]

        public async Task<ActionResult<AddressDto>> UpdateCurrentUserAddress(AddressDto addressDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var UpdatedAddress = await _serviceManager.AuthentacationService.UpdateAddressAsync(email!, addressDto);







            return Ok(UpdatedAddress);

        }

    }
}
 