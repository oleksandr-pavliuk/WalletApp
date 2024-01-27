using WalletApp.Domain.Common;
using WalletApp.Presentation.DTOs;

namespace WalletApp.Application.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        public Task<OperationResult<TransactionDto>> GetTransactionByIdAsync(int accountId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<TransactionDto>>> GetTransactionListAsync(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
