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

                if(objJSON.payload != null)
                {
                    return new OkObjectResult(objJSON);
                }
                return BadRequest("Wrong Credential.");
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("generate-otp")]
        [Produces("application/json")]
        public async Task<IActionResult> GenerateOTP([FromBody] OTP user)
        {
            try
            {
                var otp = userHelper.SendOTPEmail(user);
                OTP.Otp = otp;
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
                if (OTP.Otp == user.Otp)
                {
                    if(userHelper.CheckDuplicateEmail(user) == null)
                    {
                        var objJSON = new UserOutput();
                        objJSON.payload = userHelper.InsertUser(user);
                        return new OkObjectResult(objJSON);
                    }
                    return BadRequest("Email address already in use");
                }
                return BadRequest("OTP is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("customer")]
        [Produces("application/json")]
        public async Task<IActionResult> Customer([FromBody] UserRequest user)
        {
            try
            {
                var objJSON = new CustomerOutput();
                objJSON.payload = userHelper.GetUserById(user);

                if (objJSON.payload != null)
                {
                    return new OkObjectResult(objJSON);
                }
                return BadRequest("Wrong UserId.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("topup")]
        [Produces("application/json")]
        public async Task<IActionResult> TopUp([FromBody] TopUpRequest user)
        {
            try
            {
                var objJSON = new UserOutput();
                objJSON.payload = userHelper.TopUp(user);

                if (objJSON.payload != null)
                {
                    return new OkObjectResult(objJSON);
                }

                return BadRequest("Wrong UserId.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
