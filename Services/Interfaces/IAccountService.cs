using Banking_API.Models;
using Banking_API.Models.Responses;

namespace Banking_API.Services.Interfaces
{
    public interface IAccountService
    {
        void Reset();
        decimal? GetBalance(int accountId);
        Account Deposit(int destination, decimal amount);
        Account? Withdraw(int originId, decimal amount);
        TransferResult? Transfer(int origin, int destination, decimal amount);
    }
}
