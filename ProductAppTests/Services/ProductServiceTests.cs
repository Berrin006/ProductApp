using ProductApp.Services;
using Xunit;

namespace ProductAppTests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void AddProduct_ShouldAddProductToList()
        {
            // Arrange
            var service = new ProductService();

            // Act
            service.AddProduct("Testprodukt", 100m);

            // Assert
            Assert.Single(service.Products); // det ska bara finnas en produkt
            Assert.Equal("Testprodukt", service.Products[0].Name); // namnet ska stämma
            Assert.Equal(100m, service.Products[0].Price); // priset ska stämma
            Assert.NotEqual(Guid.Empty, service.Products[0].Id); // Id ska vara satt till ett GUID
        }
    }
}
