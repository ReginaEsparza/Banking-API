using Banking_API.Models;
using Banking_API.Models.Dtos;
using Banking_API.Services.Interfaces;

namespace Banking_API.Services
{
    public class AccountService : IAccountService
    {
        private readonly List<Account> _accounts;

        public AccountService()
        {
            _accounts = new List<Account>();
        }

        public void Reset()
        {
            _accounts.Clear();
        }

        public decimal? GetBalance(int accountId)
        {
            return _accounts.FirstOrDefault(a => a.Id == accountId)?.Balance;
        }

        public Account Deposit(int destinationId, decimal amount)
        {
            var account = GetAccount(destinationId);

            if (account == null)
            {
                return CreateAccount(destinationId, amount);
            }

            account.Balance += amount;

            return account;
        }       

        public Account? Withdraw(int originId, decimal amount)
        {
            var account = GetAccount(originId);

            if (account == null)
            {
                return null;
            }

            if(account.Balance < amount)
            {
                return null;
            }

            account.Balance -= amount;
            return account;
        }

        public Transfer? Transfer(int originId, int destinationId, decimal amount)
        {
            var withdrawnAccount = Withdraw(originId, amount);
            if (withdrawnAccount == null)
            {
                return null;
            }
            var depositedAccount = Deposit(destinationId, amount);
            return new Transfer
            {
                Origin = withdrawnAccount,
                Destination = depositedAccount
            };
        }

        private Account? GetAccount(int accountId)
        {
            return _accounts.FirstOrDefault(a => a.Id == accountId);
        }

        private Account CreateAccount(int id, decimal initialBalance)
        {
            var account = new Account { Id = id, Balance = initialBalance };
            _accounts.Add(account);
            return account;
        }
    }
}
