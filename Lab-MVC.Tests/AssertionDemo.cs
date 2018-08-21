using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region ExpectedObjects

        [Fact]
        public void ExpectedObjects_SingleObj_Demo()
        {
            //arrange
            var expected = new { Brand = Brand.Apple, Price = 399m };

            var sut = new Store();

            //act
            var actual = sut.GetTheMostExpensivePhone();

            //assert
            // 只會驗證 expected 有的 properties (方法不要用錯了，是 ShouldMatch 不是 ShouldEqual )
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void ExpectedObjects_ListObj_Demo()
        {
            //arrange
            var expected = new[]
            {
                new Phone { Brand = Brand.Apple, Price = 399m, Series = "X" },
                new Phone { Brand = Brand.Sony, Price = 299m, Series = "Xperia" },
                new Phone { Brand = Brand.Asus, Price = 100m, Series = "ZenPhone" }
            };

            var sut = new Store();

            //act
            var actual = sut.GetAllPhones();

            //assert
            // 並不會比較順序
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void ExpectedObjects_ListObj_MatchOrder_Demo()
        {
            //arrange
            var expected = new[]
            {
                new Phone { Brand = Brand.Sony, Price = 299m, Series = "Xperia" },
                new Phone { Brand = Brand.Apple, Price = 399m, Series = "X" },
                new Phone { Brand = Brand.Asus, Price = 100m, Series = "ZenPhone" }
            };

            var sut = new Store();

            //act
            var actual = sut.GetAllPhones();

            //assert
            // 會比較順序
            expected.ToExpectedObject(x => x.UseOrdinalComparison()).ShouldMatch(actual);
        }

        #endregion ExpectedObjects

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

        #region AssertIsType
        [Fact]
        public void AssertIsType_Demo()
        {
            var p = new Phone();

            Assert.IsType<Phone>(p);
            //Assert.IsNotType<Phone>(p);
        }

        [Fact]
        public void AssertIsAssignalbeFrom_Demo()
        {
            var iPhone = new IPhone();

            // 驗證 IPhone 是 Phone 的子類別
            Assert.IsAssignableFrom<Phone>(iPhone);
        } 
        #endregion
    }

    #region Sample Code

    public class Store
    {
        private List<Phone> _phones = new List<Phone>()
        {
            new Phone { Brand = Brand.Apple, Price = 399m, Series = "X" },
            new Phone { Brand = Brand.Asus, Price = 100m, Series = "ZenPhone" },
            new Phone { Brand = Brand.Sony, Price = 299m, Series = "Xperia" }
        };

        public Phone GetTheMostExpensivePhone()
        {
            return _phones.First(x => x.Brand == Brand.Apple);
        }

        public Phone GetTheCheapestPhone()
        {
            return _phones.First(x => x.Brand == Brand.Asus);
        }

        public List<Phone> GetAllPhones()
        {
            return _phones;
        }
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

    public class IPhone : Phone
    {
        public int Resolution { get; set; }
    }

    public enum Brand
    {
        Apple,
        Sony,
        Asus
    }

    #endregion Sample Code
}