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
    }
}
