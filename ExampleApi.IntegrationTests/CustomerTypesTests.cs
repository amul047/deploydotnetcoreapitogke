using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace ExampleApi.IntegrationTests
{
    public class CustomerTypesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _webApplicationFactory;

        public CustomerTypesTests(WebApplicationFactory<Startup> webApplicationFactory){
            _webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public void Get_CustomerTypes_ReturnsThreeTypes()
        {
            // Arrange
            var client = _webApplicationFactory.CreateClient();

            // Act
            var responseString = client.GetStringAsync("").GetAwaiter().GetResult();
            var customerTypes = JsonConvert.DeserializeObject<List<CustomerType>>(responseString);

            // Assert
            Assert.Equal(4, customerTypes.Count);
        }
    }
}