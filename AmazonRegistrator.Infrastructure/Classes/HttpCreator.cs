using AmazonRegistrator.Infrastructure.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class HttpCreator
    {
        public async Task<HttpAwsResponse> GetHttpResponseAsync(string uri, string data= "")
        {
            HttpAwsResponse awsResponse = new HttpAwsResponse();
            try
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                HttpWebRequest webRequest = CreateHttpWebRequest(uri, dataBytes);

                using (HttpWebResponse webResponse = (HttpWebResponse)await webRequest.GetResponseAsync())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        awsResponse = await CreateHttpAwsResponse(webResponse, reader);
                        webResponse.Close();
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            return awsResponse;
        }


        private HttpWebRequest CreateHttpWebRequest(string uri, byte[] dataBytes)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataBytes.Length;
            request.Timeout = 10000;
            request.AllowAutoRedirect = false;
            return request;
        }


        private async Task<HttpAwsResponse> CreateHttpAwsResponse(HttpWebResponse response, StreamReader reader)
        {
            var awsResponse = new HttpAwsResponse
            {
                StatusCode = (int)response.StatusCode,
                ResponseHeaders = response.Headers.ToString(),
                ResponsePage = await reader.ReadToEndAsync()
            };
            return awsResponse;
        }

    }
}
