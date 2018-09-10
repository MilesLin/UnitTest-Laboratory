using Lab_MVC.Models;
using NSubstitute;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace Lab_MVC.Controllers.Tests
{
    public class TrainControllerTests
    {
        [Fact()]
        public void Index_Without_TrainName_Test()
        {
            // Arrange
            var data = new List<Train>()
            {
                new Train(){ TrainId = 1, TrainName = "WXG-123" },
                new Train(){ TrainId = 2, TrainName = "XYZ-543" }
            }.AsQueryable();

            var mockSet = Substitute.For<DbSet<Train>, IQueryable<Train>>();
            ((IQueryable<Train>)mockSet).Provider.Returns(data.Provider);
            ((IQueryable<Train>)mockSet).Expression.Returns(data.Expression);
            ((IQueryable<Train>)mockSet).ElementType.Returns(data.ElementType);
            ((IQueryable<Train>)mockSet).GetEnumerator().Returns(data.GetEnumerator());

            var db = Substitute.For<WebPayment>();

            db.Train.Returns(mockSet);

            var sut = new TrainController(db);

            // Act
            var result = sut.Index(null) as ViewResult;
            var actual = result.Model as List<Train>;

            // Assert
            Assert.Equal(2, actual.Count);
        }

        [Fact()]
        public void Index_With_TrainName_Test()
        {
            // Arrange
            var data = new List<Train>()
            {
                new Train(){ TrainId = 1, TrainName = "WXG-123" },
                new Train(){ TrainId = 2, TrainName = "XYZ-543" }
            }.AsQueryable();

            var trainMockSet = Substitute.For<DbSet<Train>, IQueryable<Train>>();
            WireUpTheIQueryableImplementation(trainMockSet, data);

            var db = Substitute.For<WebPayment>();

            db.Train.Returns(trainMockSet);

            var sut = new TrainController(db);

            // Act
            var result = sut.Index("123") as ViewResult;
            var actual = result.Model as List<Train>;

            // Assert
            Assert.Single(actual);
        }

        private void WireUpTheIQueryableImplementation(IQueryable mockSet, IQueryable data)
        {
            mockSet.Provider.Returns(data.Provider);
            mockSet.Expression.Returns(data.Expression);
            mockSet.ElementType.Returns(data.ElementType);
            mockSet.GetEnumerator().Returns(data.GetEnumerator());
        }
    }
}