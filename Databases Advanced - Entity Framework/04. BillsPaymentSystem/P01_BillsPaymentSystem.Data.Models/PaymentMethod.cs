using P01_BillsPaymentSystem.Data.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public enum PaymentMethodType
    {
        BankAccount, CreditCard
    }
    public class PaymentMethod
    {
        public int Id { get; set; }
        public PaymentMethodType Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Xor(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
