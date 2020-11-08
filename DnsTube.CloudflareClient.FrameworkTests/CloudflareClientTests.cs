using System;
using System.Net.Http;
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
    }
}
