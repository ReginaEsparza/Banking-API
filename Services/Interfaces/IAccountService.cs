using Banking_API.Models;
using Banking_API.Models.Dtos;

namespace Banking_API.Services.Interfaces
{
    public interface IAccountService
    {
        void Reset();
        decimal? GetBalance(int accountId);
        Account Deposit(int destinationId, decimal amount);
        Account? Withdraw(int originId, decimal amount);
        Transfer? Transfer(int originId, int destinationId, decimal amount);
    }
}
