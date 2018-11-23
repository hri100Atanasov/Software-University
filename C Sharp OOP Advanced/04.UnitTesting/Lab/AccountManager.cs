using Lab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabBank
{
    class AccountManager
    {
        public BankAccount Account { get; private set; }

        public int GetBalanceInCents()
        {
            return Account.Balance;
        }
    }
}
