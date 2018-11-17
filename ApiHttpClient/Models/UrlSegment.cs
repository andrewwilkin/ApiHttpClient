using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHttpClient.Models
{
    /// <summary>
    /// For use with ApiHttpClient and ApiHttpClientAsync helper
    /// Used for adding query parameter
    /// </summary>
    public class UrlSegment
    {
        public UrlSegment(string token, string value)
        {
            Token = token;
            Value = value;
        }

        public string Token { get; }
        public string Value { get; }
    }
}
