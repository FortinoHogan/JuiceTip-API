using JuiceTip_API.Data;
using JuiceTip_API.Helper;
using JuiceTip_API.Model;
using JuiceTip_API.Output;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("rating")]
    public class RatingController : ControllerBase
    {
        private RatingHelper ratingHelper;
        public RatingController(RatingHelper ratingHelper)
        {
            this.ratingHelper = ratingHelper;
        }

        [HttpPost("insert")]
        [Produces("application/json")]
        public async Task<IActionResult> InsertRating([FromBody] RatingRequest rating)
        {
            try
            {
                var objJSON = new StatusOutput();
                objJSON = ratingHelper.InsertRating(rating);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
