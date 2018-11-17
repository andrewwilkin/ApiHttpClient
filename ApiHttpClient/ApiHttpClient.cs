using System;
using System.Collections.Generic;
using System.Text;
using ApiHttpClient.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Newtonsoft.Json.Extensions;

namespace ApiHttpClient
{
    /// <summary>
    /// Synchronous Http Client Wrapper of RestSharp
    /// Designed as testable reference implementation for JSON API Client
    /// To be expanded as projects require
    /// </summary>
    public sealed class ApiHttpClient : IApiHttpClient
    {
        private readonly ApiConfig _config;
        private readonly IRestClient _restClient;

        public ApiHttpClient(ApiConfig config, IRestClient restClient = null)
        {
            // Arguably should put this in the getter of the config class
            if (config.BaseApiUrl == null)
                throw new ArgumentNullException("Config must have BaseApiUrl Set");

            _config = config;          

            // Allow the injection of the client for testing purposes
            _restClient = restClient ?? new RestClient(_config.BaseApiUrl);

            // Switch out for a more flexible Json Deserializer
            _restClient.UseNewtonsoftJsonDeserializer();
        }

        /// <summary>
        /// Use of RestSharp with no deserialization or conversion to HttpResponse
        /// </summary>
        /// <returns>
        /// IRestResponse
        /// </returns>
        public IRestResponse Get(string resource, IEnumerable<UrlSegment> segments = null, IEnumerable<UrlParameter> parameters = null)
        {
            var request = new RestRequest(resource).AddRequestHeaders(_config, segments, parameters);
            return _restClient.Execute(request);
        }

        /// <summary>
        /// Use of RestSharp with Newtonsoft Json serializer
        /// </summary>
        /// <returns>
        /// IRestResponse
        /// </returns>
        public IRestResponse<T> Get<T>(string resource, IEnumerable<UrlSegment> segments = null, IEnumerable<UrlParameter> parameters = null) where T : new()
        {
            var request = new RestRequest(resource).AddRequestHeaders(_config, segments, parameters);
            return _restClient.Execute<T>(request);
        }


    }
}
