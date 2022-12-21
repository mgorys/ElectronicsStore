using ElectronicsStore.Abstractions.IServices;
using ElectronicsStore.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterDto dto)
        {
            await _accountService.RegisterUserAsync(dto);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoggedUserInfo>> Login([FromBody] LoginDto loginDto)
        {
            LoggedUserInfo user = await _accountService.LoginUserAsync(loginDto);
            return Ok(user);

        }
    }
}
