using System;
using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NonUnicodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Value cannot be null!");
            }

            var text = value.ToString();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > 255)
                {
                    return new ValidationResult("Value cannot contain unicode characters!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
