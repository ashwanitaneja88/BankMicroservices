namespace AccountAPI
{
    public interface IAccountRepository
    {
        List<Account> GetAllAccounts();
        Account GetAccountByEmail(string email);
        string AddMoney(Account account);
        string WithdrawMoney(Account account);
        string Delete(String email);
    }
}
