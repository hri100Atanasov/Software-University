using System;

namespace LabBank
{
    public class Bank
    {
        private AccountManager accountManager;

        public Bank()
        {
            accountManager = new AccountManager();
        }

        public string GetAccountBalance()
        {
           return accountManager.GetBalanceInCents().ToString("f2");
        }
    }
}
