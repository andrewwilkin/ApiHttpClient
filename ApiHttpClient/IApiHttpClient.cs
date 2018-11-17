using System;
using System.Collections.Generic;
using System.Text;
using ApiHttpClient.Models;
using RestSharp;

namespace ApiHttpClient
{
    public interface IApiHttpClient
    {
        /// <summary>
        /// Use of RestSharp with no deserialization or conversion to HttpResponse
        /// </summary>
        /// <returns>
        /// IRestResponse
        /// </returns>
        IRestResponse Get(string resource, IEnumerable<UrlSegment> segments = null, IEnumerable<UrlParameter> parameters = null);

        /// <summary>
        /// Use of RestSharp with Newtonsoft Json serializeer
        /// </summary>
        /// <returns>
        /// IRestResponse
        /// </returns>
        IRestResponse<T> Get<T>(string resource, IEnumerable<UrlSegment> segments = null, IEnumerable<UrlParameter> parameters = null) where T : new();
    }
}
