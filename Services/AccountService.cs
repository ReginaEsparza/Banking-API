using Banking_API.Models;
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

        public Account Deposit(int destination, decimal amount)
        {
            var account = GetAccount(destination);

            if (account == null)
            {
                return CreateAccount(destination, amount);
            }

            account.Balance += amount;

            return account;
        }       

        public Account? Withdraw(int origin, decimal amount)
        {
            var account = GetAccount(origin);

            if (account == null)
            {
                return null;
            }

            if(account.Balance < amount)
            {
                return null;// ou lançar uma exceção, dependendo do comportamento desejado
            }

            account.Balance -= amount;
            return account;
        }

        public TransferResult? Transfer(int origin, int destination, decimal amount)
        {
            var withdrawnAccount = Withdraw(origin, amount);
            if (withdrawnAccount == null)
            {
                return null;// ou lançar uma exceção, dependendo do comportamento desejado
            }
            var depositedAccount = Deposit(destination, amount);
            return new TransferResult
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
