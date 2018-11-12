using AutoFixture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lab_MVC.Tests
{
    public class AutoFixtureDemo
    {
        [Fact]
        public void CreateAnObject()
        {
            var fixture = new Fixture();

            //指定 Name 屬性為 Miles
            var employee = fixture.Build<Employee>()
                .With(x => x.Name, "Miles")
                .Create();
        }

        [Theory]
        [InlineData(1,2,false)]
        [InlineData(2,1,true)]
        [InlineData(5,5,false)]
        public void GreaterToTest(int number1, int number2, bool expected)
        {
            // Arrange
            var sut = new Comparer();

            // Act
            var actual = sut.GreaterTo(number1, number2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Comparer
    {
        public bool GreaterTo(int a, int b)
        {
            return a > b;
        }
    }
}
