using System.Collections.Generic;
using System.Linq;
using ApiHttpClient.Models;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace ApiHttpClient.Tests
{
    [TestFixture]
    public class ApiRequestHeaderTests
    {
        [Test]
        public void AddRequestHeaders_ConfigHeadersList_CallsAddHeader()
        {
            var config = new ApiConfig();
            config.Headers.Add(new RequestHeader { Key = "Key", Value = "Value" });
            var request = new Mock<IRestRequest>();
            request.Object.AddRequestHeaders(config);
            request.Verify(x => x.AddHeader("Key", "Value"), Times.Once);
        }

        [Test]
        public void AddRequestHeaders_UrlSegmentsList_CallsAddUrlSegment()
        {
            var config = new ApiConfig();
            var segments = new List<UrlSegment>() { new UrlSegment("Token","Value") };
            var request = new Mock<IRestRequest>();
            request.Object.AddRequestHeaders(config,segments);
            request.Verify(x => x.AddUrlSegment("Token", "Value"), Times.Once);
        }

        [Test]
        public void AddRequestHeaders_UrlParametersList_CallsAddParameter()
        {
            var config = new ApiConfig();
            var parameters = new List<UrlParameter>() { new UrlParameter("Name", "Value") };
            var request = new Mock<IRestRequest>();
            request.Object.AddRequestHeaders(config, null, parameters);
            request.Verify(x => x.AddParameter("Name", "Value"), Times.Once);
        }
    }
}
