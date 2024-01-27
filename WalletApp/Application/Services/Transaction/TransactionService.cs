using WalletApp.Domain.Common;
using WalletApp.Infrastructure.DatabaseContext;
using WalletApp.Presentation.DTOs;

namespace WalletApp.Application.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationContext _context;
        public TransactionService(ApplicationContext context) 
        { 
            _context = context;
        }
        public Task<OperationResult<TransactionDto>> GetTransactionByIdAsync(int accountId, int id)
        {
            var transaction 
        }

        public Task<OperationResult<List<TransactionDto>>> GetTransactionListAsync(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
