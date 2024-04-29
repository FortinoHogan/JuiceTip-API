using JuiceTip_API.Data;
using JuiceTip_API.Helper;
using JuiceTip_API.Output;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private CategoryHelper categoryHelper;
        public CategoryController(CategoryHelper categoryHelper)
        {
            this.categoryHelper = categoryHelper;
        }

        [HttpPost("")]
        [Produces("application/json")]
        public async Task<IActionResult> Category([FromBody] CategoryRequest category)
        {
            try
            {
                var objJSON = new CategoryOutput();
                objJSON.payload = categoryHelper.GetCategory(category);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
