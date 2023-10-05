using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Moq;
using NewEvilWeatherControlApp;
using System.Security.Claims;

namespace EvilWeatherControlApp.Tests
{
    public class Tests
    {
        [Test]
        public async Task BodyIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            var requestData = new FakeRequestData();
            var functions = new Functions(null);

            // Act
            var result = await functions.Run(requestData, "Mars");

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        class FakeRequestData : HttpRequestData
        {
            private static readonly FunctionContext Context = Mock.Of<FunctionContext>();

            public FakeRequestData() : base(Context)
            {
            }

            public override Stream Body => new MemoryStream();
            public override HttpHeadersCollection Headers { get; }
            public override IReadOnlyCollection<IHttpCookie> Cookies { get; }
            public override Uri Url { get; }
            public override IEnumerable<ClaimsIdentity> Identities { get; }
            public override string Method { get; }

            public override HttpResponseData CreateResponse()
            {
                throw new NotImplementedException();
            }
        }
    }

}