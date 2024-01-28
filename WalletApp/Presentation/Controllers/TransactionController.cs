using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.Services.Transaction;

namespace WalletApp.Presentation.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transaction;

        public TransactionController(ITransactionService transaction)
        {
            _transaction = transaction;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetTransactionList([FromQuery]int id)
        {
            var result = await _transaction.GetTransactionListAsync(id);

            if(!result.IsSuccessful)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionById([FromQuery]int id)
        {
            var result = await _transaction.GetTransactionByIdAsync(id);

            if (!result.IsSuccessful)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }
    }
}
