using WalletApp.Domain.Common;
using WalletApp.Presentation.DTOs;

namespace WalletApp.Application.Services.Transaction
{
    public interface ITransactionService
    {
        Task<OperationResult<List<TransactionDto>>> GetTransactionListAsync(int accountId);
        Task<OperationResult<TransactionDto>> GetTransactionByIdAsync(int id);
    }
}
