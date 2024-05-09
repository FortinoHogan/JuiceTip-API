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
    [Route("transaction-detail")]
    public class TransactionDetailController : ControllerBase
    {
        private TransactionDetailHelper transactionDetailHelper;
        public TransactionDetailController(TransactionDetailHelper transactionDetailHelper)
        {
            this.transactionDetailHelper = transactionDetailHelper;
        }

        [HttpPost("insert")]
        [Produces("application/json")]
        public async Task<IActionResult> InsertTransactionDetail([FromBody] TransactionDetail transactionDetail)
        {
            try
            {
                var objJSON = new StatusOutput();
                objJSON = transactionDetailHelper.InsertTransactionDetail(transactionDetail);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
