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
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
