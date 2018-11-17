using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiHttpClient.Models;
using RestSharp;

namespace ApiHttpClient
{
    public interface IApiHttpClientAsync
    {
        /// <summary>
        /// Use of RestSharp with no deserialization or conversion to HttpResponse
        /// </summary>
        /// <returns>
        /// IRestResponse
        /// </returns>
        Task<IRestResponse> Get(string resource, IEnumerable<UrlSegment> segments = null, IEnumerable<UrlParameter> parameters = null);

        /// <summary>
        /// Use of RestSharp with Newtonsoft Json serializer
        /// </summary>
        /// <returns>
        /// IRestResponse
        /// </returns>
        Task<IRestResponse<T>> Get<T>(string resource, IEnumerable<UrlSegment> segments = null, IEnumerable<UrlParameter> parameters = null) where T : new();
    }
}
