using Lab;
using NUnit.Framework;
using System;

namespace UnitTesterTestsLab
{
    public class UnitTesterLabTests
    {
       private BankAccount bankAccount;

        [SetUp]
        public void InitializeTest()
        {
            bankAccount = new BankAccount();
        }

        [Test]
        public void DepositeShouldIncreaseBalance()
        {
            bankAccount.Deposite(10);
            Assert.That(bankAccount.Balance, Is.EqualTo(10));
        }

        [TestCase(10)]
        [TestCase(-10)]
        [TestCase(100)]
        public void WithDrawTest(int amount)
        {
            Assert.Throws<Exception>(() => bankAccount.Withdraw(amount));
        }
    }
}
