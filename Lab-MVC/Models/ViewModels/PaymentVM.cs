using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab_MVC.Models.ViewModels
{
    public class PaymentVM : IValidatableObject
    {
        [Range(0, 10)]
        public decimal Price { get; set; }

        [Required]
        public string CreditCard { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price <= 0)
            {
                yield return new ValidationResult("金額不能小於0元", new[] { "Price" });
            }

            if (string.IsNullOrEmpty(Address1) && string.IsNullOrEmpty(Address2))
            {
                yield return new ValidationResult("請輸入地址", new[] { "Address1", "Address2" });
            }
        }
    }
}