using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHttpClient.Models
{
    /// <summary>
    /// For use with ApiHttpClient and ApiHttpClientAsync helper
    /// It would be used to substitute tokens in request strings
    /// </summary>
    public class UrlParameter
    {
        public UrlParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}
