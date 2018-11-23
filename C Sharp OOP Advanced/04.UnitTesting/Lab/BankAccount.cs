using System;

namespace Lab
{
    public class BankAccount
    {
        public int Balance { get; set; }

        public void Deposite(int amount)
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (Balance<amount)
            {
                throw new Exception("Not enough vespine gas!");
            }
            Balance -= amount;
        }
    }
}
