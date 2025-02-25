using AccountAPI.Controllers;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace AccountAPI
{
    public class AccountRepository : IAccountRepository
    {
        private static List<Account> _accounts = new()
        {
         new()
         {
              CustomerEmail = "at@Gmail.com",
                Amount = 100
         },
         new()
         {
              CustomerEmail = "a2@Gmail.com",
                Amount = 50
         },
         new()
         {
             CustomerEmail = "a3@Gmail.com",
                Amount = 10
         }
        };

        public List<Account> GetAllAccounts() => _accounts;

        public Account GetAccountByEmail(string email) => _accounts.FirstOrDefault(x => x.CustomerEmail.ToLower() == email.ToLower());

        public string AddMoney(Account account)
        {
            string response = "Account do not exists";
            var accountToBeUpdated = _accounts.FirstOrDefault(x => x.CustomerEmail.ToLower() == account.CustomerEmail.ToLower());

            if (accountToBeUpdated != null)
            {
                _accounts.Remove(accountToBeUpdated);
                account.Amount = accountToBeUpdated.Amount + account.Amount;
                _accounts.Add(account);
                response = "amount is added";
            }
            return response;
        }

        public string WithdrawMoney(Account account)
        {
            string response = "Account do not exists";
            var accountToBeUpdated = _accounts.FirstOrDefault(x => x.CustomerEmail.ToLower() == account.CustomerEmail.ToLower());
            if (accountToBeUpdated != null)
            {
                if (account.Amount > accountToBeUpdated.Amount)
                {
                    return "withdrawn amount is more than the amount in the account";
                }
                _accounts.Remove(accountToBeUpdated);
                account.Amount = accountToBeUpdated.Amount - account.Amount;
                _accounts.Add(account);
                response = "Money is withdrawn";
            }
            return response;
        }
        public string Delete(String email)
        {
            string response = "account do not exists";
            var customerToUpdate = _accounts.FirstOrDefault(x => x.CustomerEmail.ToLower() == email.ToLower());
            if (customerToUpdate != null)
            {
                _accounts.Remove(customerToUpdate);
                response = "account is deleted";
            }
            return response;
        }

    }
}
