using System;
using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class XorAttribute : ValidationAttribute
    {
        private string xorTargetAttribute;
        public XorAttribute(string xorTargetAttribute)
        {
            this.xorTargetAttribute = xorTargetAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetValue = validationContext.ObjectType.GetProperty(xorTargetAttribute).GetValue(validationContext.ObjectInstance);

            if ((targetValue==null&&value!=null)||(targetValue!=null&&value==null))
            {
               return ValidationResult.Success;
            }
            return new ValidationResult("Please select only one type of payment!");
        }
    }
}
