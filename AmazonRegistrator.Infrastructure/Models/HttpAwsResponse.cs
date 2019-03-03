using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmazonRegistrator.Infrastructure.Models
{
    public class HttpAwsResponse
    {
        public int StatusCode { get; set; }
        public string ResponseHeaders { get; set; }
        public string ResponsePage { get; set; }
    }
}
