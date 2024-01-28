using WalletApp.Domain.Common;

namespace WalletApp.Application.Services.Account
{
    public interface IUserService
    {
        Task<OperationResult<decimal>> GetUserBalanceAsync(int userId);
        Task<OperationResult<double>> GetUserPointsAsync(int userId);
    }
}
