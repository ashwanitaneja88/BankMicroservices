using Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace AccountAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountRepository _accountRepository;

        public AccountsController(ILogger<AccountsController> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        [HttpGet("Get")]
        public IActionResult Get() => Ok(_accountRepository.GetAllAccounts());

        [HttpGet("GetAccountByEmail")]
        public IActionResult GetAccount(string email)
        {
            if (!Helper.ValidateCustomer(email))
            {
                return BadRequest("email is not allowed");
            }
            return Ok(_accountRepository.GetAccountByEmail(email));
        }

        [HttpPost("AddMoney")]
        public IActionResult AddMoney(Account account)
        {
            if (!Helper.ValidateCustomer(account.CustomerEmail))
            {
                return BadRequest("email is not allowed");
            }
            return Ok(_accountRepository.AddMoney(account));
        }

        [HttpPost("WithdrawMoney")]
        public IActionResult WithdrawMoney(Account account)
        {
            if (!Helper.ValidateCustomer(account.CustomerEmail))
            {
                return BadRequest("email is not allowed");
            }
            return Ok(_accountRepository.WithdrawMoney(account));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(String email)
        {
            if (!Helper.ValidateCustomer(email))
            {
                return BadRequest("email is not allowed");
            }
            return Ok(_accountRepository.Delete(email));
        }
       
    }
}