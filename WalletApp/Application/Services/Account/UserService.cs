using Microsoft.EntityFrameworkCore;
using WalletApp.Domain;
using WalletApp.Domain.Common;
using WalletApp.Infrastructure.DatabaseContext;

namespace WalletApp.Application.Services.Account
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        public UserService(ApplicationContext context) 
        {
            _context = context;
        }    

        public async Task<OperationResult<decimal>> GetUserBalanceAsync(int userId)
        {
            var balance = await _context.Users.Where(u => u.Id == userId).Select(u => u.Balance).FirstOrDefaultAsync();

            if (balance == default)
                return OperationResult<decimal>.Failure("User is not exist . . .");

            return OperationResult<decimal>.Success(data: balance);
        }

        public async Task<OperationResult<double>> GetUserPointsAsync(int userId)
        {
            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var currentDate = DateOnly.FromDateTime(DateTime.UtcNow);

            if (user == null)
                return OperationResult<double>.Failure("User is not exist . . .");

            if (user.LastDatePoint != currentDate)
                await CalculatePoints(user, currentDate);

            return OperationResult<double>.Success(data: user.Points);
        }

        private async Task<OperationResult<double>> CalculatePoints(User user, DateOnly currentDate)
        {
            double pointsToAdd = 0;
            
            int season = (currentDate.Month - 1) / 3 + 1;
            int dayOfSeason = currentDate.DayNumber - DateOnly.FromDateTime(new DateTime(currentDate.Year, (season - 1) * 3 + 1, 1)).DayNumber + 1;
               
            switch (dayOfSeason)
            {
                case 1:
                    pointsToAdd = 2;
                    break;
                case 2: 
                    pointsToAdd = 3;
                    break;
                default:
                    pointsToAdd = (1.0 * user.LastPoint + 0.6 * user.PreLastPoint);
                    break;
            }
            user.Points += pointsToAdd;
            user.PreLastPoint = user.LastPoint;
            user.LastPoint = pointsToAdd;
            user.LastDatePoint = currentDate;

            await _context.SaveChangesAsync();

            return OperationResult<double>.Success(pointsToAdd);
        }
    }
}
