using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using baroudeurs;


namespace baroudeursTests;



public class HomeControllerTests
     
    : IClassFixture<WebApplicationFactory<baroudeurs.Startup>>
    {
        private readonly WebApplicationFactory<baroudeurs.Startup> _factory;

        public HomeControllerTests(WebApplicationFactory<baroudeurs.Startup> factory)
        {
            _factory = factory;
        }

// Tests pour les Controllers
        [Theory]
        
        [InlineData("/City")]
        [InlineData("/City/Create")]
        [InlineData("/Discovery/Index")]
        [InlineData("/Home/Index")]
        [InlineData("/Point")]
        [InlineData("/Point/Details/1")]
        [InlineData("/User")]
        [InlineData("/User/Delete/2")]
     
      
      
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }


// Tests pour les API
         [Theory]
         [InlineData("/api/APIUser")]
         [InlineData("/api/APIPoint")]
         [InlineData("/api/APIDiscovery")]

         public async Task Get_EndpointsAPIReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }




    