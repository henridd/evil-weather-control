using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvilWeatherControlApp.Tests
{
    public class Tests
    {
        [Test]
        public async Task BodyIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();

            // Act
            var result = await Functions.Run(httpContext.Request, "Mars", null);

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }
    }
}