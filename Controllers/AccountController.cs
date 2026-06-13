using Banking_API.Models.Dtos;
using Banking_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banking_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("reset")]
        public IActionResult Reset()
        {
            return Ok();
        }

        [HttpGet("balance/{account_id}")]
        public IActionResult GetBalance(int account_id) 
        {
            var balance = _accountService.GetBalance(account_id);

            if(balance == null) {
                return BadRequest(balance);
            }
            return Ok(balance);
        }

        [HttpPost("event")]
        public IActionResult Event(EventRequest request)
        {
            switch (request.Type)
            {
                case "deposit" when int.TryParse(request.Destination, out var destinationId):
                {
                    var account = _accountService.Deposit(destinationId, request.Amount);

                    return Created(string.Empty, new
                    {
                        destination = account
                    });
                }

                case "withdraw" when int.TryParse(request.Origin, out var originId):
                {
                    var account = _accountService.Withdraw(originId, request.Amount);

                    if (account is null)
                    {
                        return NotFound(0);
                    }

                    return Created(string.Empty, new
                    {
                        origin = account
                    });
                }

                case "transfer" when int.TryParse(request.Origin, out var originId)
                                      && int.TryParse(request.Destination, out var destinationId):
                {
                    var result = _accountService.Transfer(originId, destinationId, request.Amount);

                    if (result is null)
                    {
                        return NotFound(0);
                    }

                    return Created(string.Empty, new
                    {
                        origin = result.Origin,
                        destination = result.Destination
                    });
                }

                default:
                    return BadRequest();
            }
        }
    }
}
