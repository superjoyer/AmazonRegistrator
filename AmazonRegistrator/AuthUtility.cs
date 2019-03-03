using AmazonRegistrator.Infrastructure.Classes;
using AmazonRegistrator.Infrastructure.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AmazonRegistrator.Core
{
    public class AuthUtility
    {


        public async void Autentificate()
        {
            var authUtility = new AuthFacade();
            HttpAwsResponse response;
            bool wait = true;


            DateTime? oldCreatedDate = authUtility.GetSmsLastCreatedDate();
            Console.WriteLine("Last Recented Date: {0}", oldCreatedDate);

            authUtility.LoginToAwsWithAccountAttrs();

            try
            {
                response = authUtility.GetHttp();
                if (response.StatusCode != 200)
                    throw new HttpException("Invalid Auth response page code ...");

                Console.WriteLine("Response Code: {0}", response.StatusCode);

                await Task.Run(() =>
                {
                    do
                    {
                        Console.WriteLine("Wait ...");

                        // Wait 10 secunds to get new income message to twilio
                        Thread.Sleep(10000);

                        var newCreatedDate = authUtility.GetSmsLastCreatedDate();

                        if (newCreatedDate == oldCreatedDate) continue;
                        wait = false;
                        Console.WriteLine("Read recerved new message");
                    } while (wait);

                }).ContinueWith(t =>
                {
                    var authCode = authUtility.GetVerificateCode();

                    Console.WriteLine("New verfication code received: {0}\n", authCode);
                    Console.WriteLine("Pass auth code ...\n");

                    authUtility.LoginToAwsWithResponcedCode(authCode);

                }).ContinueWith(t => {

                    response = authUtility.GetHttp();
                    if (response.StatusCode != 200) throw new HttpException("Invalid Auth response page code ...");


                    Console.WriteLine("Authentication successful\n");
                    Console.WriteLine("Response Code: {0}", response.StatusCode);
                    Console.WriteLine("Response Headers: {0}", response.ResponseHeaders);

                });
            }
            catch (HttpException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }
        }
    }
}
