using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Lab_MVC.Models.ViewModels.Tests
{
    public class PaymentVMTests
    {
        [Fact()]
        public void ValidateTest()
        {
            // Arrange
            var model = new PaymentVM()
            {
                Price = 10
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var result = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, validateAllProperties: true);

            //validateAllProperties = true 會驗證 Range，反之不會。
            //https://stackoverflow.com/questions/5636975/validator-validateobject-with-validateallproperties-to-true-stop-at-first-erro/5637762

            //attribute 都通過，才會驗證 Validate 的內容，否則不會驗證 Valiate 的邏輯。

            // Assert
            Assert.False(result);
            Assert.Equal("CreditCard", validationResults[0].MemberNames.ElementAt(0));
            Assert.Equal("The CreditCard field is required.", validationResults[0].ErrorMessage);
        }
    }
}