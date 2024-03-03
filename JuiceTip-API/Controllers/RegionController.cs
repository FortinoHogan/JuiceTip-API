using JuiceTip_API.Data;
using JuiceTip_API.Helper;
using JuiceTip_API.Output;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("region")]
    public class RegionController : ControllerBase
    {
        private RegionHelper regionHelper;
        public RegionController(RegionHelper regionHelper)
        {
            this.regionHelper = regionHelper;
        }

        [HttpPost("")]
        [Produces("application/json")]
        public async Task<IActionResult> Region([FromBody] RegionRequest region)
        {
            try
            {
                var objJSON = new RegionOutput();
                objJSON.payload = regionHelper.GetRegion(region);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
