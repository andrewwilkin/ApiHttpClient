using System;
using System.Collections.Generic;
using ApiHttpClient.Models;

namespace ApiHttpClient.Models
{
    public class ApiConfig
    {
        public Uri BaseApiUrl { get; set; }

        public List<RequestHeader> Headers { get; set; } = new List<RequestHeader>();
    }
}
