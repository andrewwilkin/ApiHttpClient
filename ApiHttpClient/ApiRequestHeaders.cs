using System;
using System.Collections.Generic;
using System.Text;
using ApiHttpClient.Models;
using RestSharp;

namespace ApiHttpClient
{
    public static class ApiRequestHeaders
    {
        public static IRestRequest AddRequestHeaders(this IRestRequest request, ApiConfig config, IEnumerable<UrlSegment> segments = null, IEnumerable<UrlParameter> parameters = null)
        {
            // Add in any standard headers
            foreach (var header in config.Headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            // Add in any standard segments (tokens in the resource get substituted)
            if (segments != null)
            {
                foreach (var segment in segments)
                {
                    request.AddUrlSegment(segment.Token, segment.Value);
                }
            }

            // Add in any parameters (query string)
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Name, parameter.Value);
                }
            }

            return request;
        }
    }
}
