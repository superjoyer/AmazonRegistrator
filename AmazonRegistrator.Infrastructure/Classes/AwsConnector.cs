using AmazonRegistrator.Infrastructure.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class AwsConnector : IConnect
    {
        public AwsConnector()
        {

        }

        public void Login(string userName = null, string password = null)
        {
            var responce = HttpAwsPostAsync().Result;
            Console.WriteLine(responce);
        }



        private async Task<string> HttpAwsPostAsync(string method = "POST")
        {
            string uri = "https://www.amazon.com/ap/signin?_encoding=UTF8&ignoreAuthState=1&openid.assoc_handle=usflex&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.mode=checkid_setup&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&openid.ns.pape=http%3A%2F%2Fspecs.openid.net%2Fextensions%2Fpape%2F1.0&openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2F%3Fref_%3Dnav_custrec_signin&switch_account=";
            string contentType = "text/html;charset=UTF-8";
            string data = "email=orders@24-7books.com&password=buybooks123";
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;

            using (Stream requestBody = request.GetRequestStream())
            {
                await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                Console.WriteLine("Status Code:" + (int)response.StatusCode);
                Console.WriteLine("Headers:\n" + response.Headers);



                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }




        //static async void HTTP_GET()
        //{
        //    string baseUrl = "https://www.amazon.com/ap/" +
        //                     "signin?_encoding=UTF8&ignoreAuthState=1&openid.assoc_handle=usflex&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.mode=checkid_setup&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&openid.ns.pape=http%3A%2F%2Fspecs.openid.net%2Fextensions%2Fpape%2F1.0&openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2F%3Fref_%3Dnav_custrec_signin&switch_account=";
           

         

        //    Console.WriteLine("GET: + " + baseUrl);

        //    // ... Use HttpClient.            
        //    HttpClient client = new HttpClient();

        //    var byteArray = Encoding.ASCII.GetBytes("orders@24-7books.com:buybooks123");
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));


        //    using (HttpResponseMessage response = await client.GetAsync(baseUrl))
        //    {
        //        using (HttpContent content = response.Content)
        //        {

        //            // ... Check Status Code                                
        //            Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

        //            // ... Read the string.
        //           // string result = await content.ReadAsStringAsync();
        //            string result = Encoding.UTF8.GetString(await content.ReadAsByteArrayAsync());

        //            // ... Display the result.
        //            if (result != null &&
        //            result.Length >= 50)
        //            {
        //                Console.WriteLine(result.Substring(0, 50) + "...");
        //                Console.WriteLine(result);
        //            }
        //        }
        //    }
        //}


    }

}
