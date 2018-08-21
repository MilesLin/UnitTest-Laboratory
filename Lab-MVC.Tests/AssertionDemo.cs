using System;
using Xunit;

namespace Lab_MVC.Tests
{
    [Trait("Category", "Assertion")]
    public class AssertionDemo
    {
        #region AssertEqual

        [Fact]
        public void AssertEqual_ValueDemo()
        {
            int a = 1;
            int b = 1;

            Assert.Equal(a, b);
        }

        [Fact]
        public void AssertEqual_ObjectDemo()
        {
            var p1 = new Phone { Brand = Brand.Apple };
            var p2 = new Phone { Brand = Brand.Apple };

            // Fail: 因為參考不一樣
            Assert.Equal(p1, p2);
        }

        [Fact]
        public void AssertEqual_DecimalDemo()
        {
            decimal a = 123.3211m;
            decimal b = 123.3215m;

            // Decimal(double) 可傳入精準度
            Assert.Equal(a, b, 2);
        }

        #endregion AssertEqual

        #region AssertTrueAndFalse

        [Fact]
        public void AssertTrue_Demo()
        {
            var result = true;

            Assert.True(result);
            //Assert.True(result, "測試失敗顯示的自定訊息");

            //Assert.False(result);

            /*
            禁止這樣做，因為會造成結果不明確
            */
            //string a = "Miles";
            //string b = "Grey";
            //Assert.True(a == b);
        }

        #endregion AssertTrueAndFalse

        #region AssertNullAndNotNull

        [Fact]
        public void AssertNullAndNotNull_Demo()
        {
            object result = null;

            Assert.Null(result);
            //Assert.NotNull(result);
        }

        #endregion AssertNullAndNotNull

        #region AssertInRangeAndNotRange

        [Fact]
        public void AssertInRangeAndNotRange_Demo()
        {
            int result = 10;

            Assert.InRange(result, 0, 10);
            //Assert.NotInRange(result, 0, 10);
        }

        #endregion AssertInRangeAndNotRange

        #region AssertContainersAndDoesNotContain

        [Fact]
        public void AssertContainersAndDoesNotContain_Demo()
        {
            var names = new[] { "Sarah", "Amrit" };

            Assert.Contains("Sarah", names);
            //Assert.DoesNotContain("Sarah", names);
        }

        #endregion AssertContainersAndDoesNotContain

        #region AssertThrowException

        [Fact]
        public void AssertThrowException_Demo()
        {
            var sut = new Calculator();

            Assert.Throws<DivideByZeroException>(() =>
                sut.Divide(10, 0)
            );

            // 如果沒有 throw exception 會 failure
            //Assert.Throws<DivideByZeroException>(() =>
            //    sut.Divide(10, 2)
            //);

            // 可以取得 Exception 資訊，做更進一步的驗證
            //var ex = Assert.Throws<DivideByZeroException>(() =>
            //    sut.Divide(10, 0)
            //);
            //Assert.NotEmpty(ex.Message);
        }

        #endregion AssertThrowException        
    }

    public class Calculator
    {
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }

    public class Phone
    {
        public Brand Brand { get; set; }

        public string Series { get; set; }

        public decimal Price { get; set; }
    }

    public enum Brand
    {
        Apple,
        Sony,
        Asus
    }
}