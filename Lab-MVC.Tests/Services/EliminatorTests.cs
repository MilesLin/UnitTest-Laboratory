using Xunit;

namespace Lab_MVC.Services.Tests
{
    public class EliminatorTests
    {
        [Fact()]
        public void EliminateSpaceTest()
        {
            // Arrange
            var obj = new Container
            {
                ContainerId = 1,
                ContainerName = "TEMU2934238    ",
                ContainerType = "  Reefer "
            };
            var expected = new Container
            {
                ContainerId = 1,
                ContainerName = "TEMU2934238",
                ContainerType = "Reefer"
            };

            var sut = new Eliminator();

            // Act
            var actual = sut.EliminateSpace(obj);

            // Assert
            Assert.Equal(expected.ContainerId, actual.ContainerId);
            Assert.Equal(expected.ContainerName, actual.ContainerName);
            Assert.Equal(expected.ContainerType, actual.ContainerType);
        }

        public class Container
        {
            public int ContainerId { get; set; }
            public string ContainerName { get; set; }
            public string ContainerType { get; set; }
        }
    }
}