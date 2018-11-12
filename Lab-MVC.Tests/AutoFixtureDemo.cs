using AutoFixture;
using AutoFixture.Xunit2;
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

            var employee = fixture.Build<Employee>()
                .With(x => x.Name, "Miles")
                .Create();
        }

        [Theory]
        [AutoData]
        [InlineAutoData(2)]
        public void GreaterToTest(int number1, int number2)
        {
            // Arrange
            var sut = new Comparer();
            bool expected = number1 > number2;

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
