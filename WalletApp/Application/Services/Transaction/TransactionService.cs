using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.Common;
using WalletApp.Infrastructure.DatabaseContext;
using WalletApp.Presentation.DTOs;

namespace WalletApp.Application.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public TransactionService(ApplicationContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<TransactionDto>> GetTransactionByIdAsync(int id)
        {
            var transaction = await _context.Transactions.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (transaction is null)
                return OperationResult<TransactionDto>.Failure("Transaction not found ...");

            return OperationResult<TransactionDto>.Success(data: _mapper.Map<TransactionDto>(transaction));
        }

        public async Task<OperationResult<List<TransactionDto>>> GetTransactionListAsync(int userId)
        {
            var transactionList = await _context.Transactions.Where(t => t.UserId == userId).ToListAsync();

            List<TransactionDto> transactionDtos = new List<TransactionDto>();

            foreach (var transaction in transactionList)
            {
                transactionDtos.Add(_mapper.Map<TransactionDto>(transaction));
            }

            if (transactionList is null)
                return OperationResult<List<TransactionDto>>.Failure("Transaction not found ...");

            return OperationResult<List<TransactionDto>>.Success(data: transactionDtos);
        }
    }
}
