using JuiceTip_API.Data;
using JuiceTip_API.Helper;
using JuiceTip_API.Output;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private UserHelper userHelper;
        public UserController(UserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        [HttpPost("login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromBody] LoginRequest user)
        {
            try
            {
                var objJSON = new UserOutput();
                objJSON.payload = userHelper.GetUser(user);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("generate-otp")]
        [Produces("application/json")]
        public async Task<IActionResult> GenerateOTP([FromBody] RegisterRequest user)
        {
            try
            {
                var otp = userHelper.SendOTPEmail(user.FirstName, user.Email);
                OTP.otp = otp;
                return new OkObjectResult("Success Send OTP");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        [Produces("application/json")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest user)
        {
            try
            {
                if (OTP.otp == user.Otp)
                {
                    var objJSON = new UserOutput();
                    objJSON.payload = userHelper.UpsertUser(user);
                    return new OkObjectResult(objJSON);
                }
                return BadRequest("OTP is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
