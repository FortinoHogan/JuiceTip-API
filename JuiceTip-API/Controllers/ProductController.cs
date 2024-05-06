using JuiceTip_API.Data;
using JuiceTip_API.Helper;
using JuiceTip_API.Output;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {
        private ProductHelper productHelper;
        public ProductController(ProductHelper productHelper)
        {
            this.productHelper = productHelper;
        }

        [HttpPost("upsert")]
        [Produces("application/json")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest product)
        {
            try
            {
                var objJSON = new ProductOutput();
                objJSON.payload = productHelper.UpsertProduct(product);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        [Produces("application/json")]
        public async Task<IActionResult> Products()
        {
            try
            {
                var objJSON = new AllProductOutput();
                objJSON.payload = productHelper.GetProducts();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("id")]
        [Produces("application/json")]
        public async Task<IActionResult> Product([FromBody] ProductByIdRequest product)
        {
            try
            {
                var objJSON = new ProductByIdOutput();
                objJSON.payload = productHelper.GetProductById(product);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteProduct([FromBody] ProductByIdRequest product)
        {
            try
            {
                var objJSON = new StatusOutput();
                objJSON = productHelper.DeleteProductById(product.ProductId);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
