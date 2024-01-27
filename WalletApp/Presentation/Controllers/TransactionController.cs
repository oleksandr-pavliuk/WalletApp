using Microsoft.AspNetCore.Http;
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

        [HttpGet("get-transaction-list/{id}")]
        public async Task<IActionResult> GetTransactionList(int id)
        {
            var result = await _transaction.GetTransactionListAsync(id);

            if(!result.IsSuccessful)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        
    }
}
