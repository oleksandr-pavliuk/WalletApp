using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.Services.Account;

namespace WalletApp.Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetUserBalance([FromQuery] int id)
        {
            var result = await _user.GetUserBalanceAsync(id);

            if(!result.IsSuccessful)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("points")]
        public async Task<IActionResult> GetUserPoints([FromQuery] int id)
        {
            var result = await _user.GetUserPointsAsync(id);

            if (!result.IsSuccessful)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

    }
}
