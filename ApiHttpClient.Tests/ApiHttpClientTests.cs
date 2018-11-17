using System;
using ApiHttpClient.Models;
using NUnit.Framework;

namespace ApiHttpClient.Tests
{
    [TestFixture]
    public class ApiHttpClientTests
    {
        [Test]
        public void Constructor_NonNullBaseApiUrl_DoesNotThrowException()
        {
            var config = new ApiConfig { BaseApiUrl = new Uri("http://example.com")};
            Assert.That(() => { new ApiHttpClient(config); }, Throws.Nothing);
        }

        [Test]
        public void Constructor_NullBaseApiUrl_ThrowsException()
        {
            var config = new ApiConfig();
            Assert.That(() => { new ApiHttpClient(config);}, Throws.ArgumentNullException);
        }
    }
}
