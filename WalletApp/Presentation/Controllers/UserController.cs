using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.Services.Account;

namespace WalletApp.Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _account;
        public UserController(IUserService account)
        {
            _account = account;
        }

    }
}
