using DnsTube.CloudflareClient.Models.Zone;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DnsTube.CloudflareClient.FrameworkTests
{
    public class CloudflareClientTests
    {
        [Fact]
        public void NullHttpClientPassedToConstructorShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CloudflareClient(null, "token"));
        }

        [Fact]
        public void NullTokenPassedToConstructorShouldThrowArgumentNullException()
        {
            var httpClient = new HttpClient();

            Assert.Throws<ArgumentNullException>(() => new CloudflareClient(httpClient, null));
        }

        [Fact]
        public void NullApiKeyPassedToConstructorShouldThrowArgumentNullException()
        {
            var httpClient = new HttpClient();

            Assert.Throws<ArgumentNullException>(() => new CloudflareClient(httpClient, null, "email@example.com"));
        }

        [Fact]
        public void NullEmailAddressPassedToConstructorShouldThrowArgumentNullException()
        {
            var httpClient = new HttpClient();

            Assert.Throws<ArgumentNullException>(() => new CloudflareClient(httpClient, "key-123456", null));
        }

        [Fact]
        public async Task GetZoneIdsAsyncShouldReturnEnumerableOfZones()
        {
            var content = File.ReadAllText("getZoneIdsSuccessResponse.json");

            // arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                                                    ItExpr.IsAny<HttpRequestMessage>(),
                                                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(content)
                });

            var cfClient = new CloudflareClient(new HttpClient(mockMessageHandler.Object), "token");

            // act
            var result = await cfClient.GetZoneIdsAsync();

            // assert
            Assert.IsAssignableFrom<IEnumerable<Zone>>(result);
        }
    }
}
