using AwsAuthUtility.Infrastructure.Classes;
using AwsAuthUtility.Infrastructure.Models;
using System;
using System.Diagnostics;
using System.Threading;
using System.Web;

namespace AwsAuthUtility.Core
{
    public class AuthUtility
    {
        public async void Auth()
        {
            var authUtility = new AuthFacade();
            HttpAwsResponse response;


            DateTime? oldCreatedDate = authUtility.GetSmsLastCreatedDate();
            Console.WriteLine("Last Recented Date: {0}", oldCreatedDate);

            authUtility.LoginToAwsWithAccountAttrs();

            try
            {
                response = authUtility.GetHttp();
                if (response.StatusCode != 200) throw new HttpException("Invalid Auth response page code ...");

                Console.WriteLine("Response Code: {0}", response.StatusCode);

                WaitAuthCode(oldCreatedDate, authUtility);


                var authCode = authUtility.GetVerificationCode();
                Console.WriteLine("New verfication code received: {0}\nPass auth code ...\n", authCode);
                authUtility.LoginToAwsWithResponseCode(authCode);



                response = authUtility.GetHttp();
                if (response.StatusCode != 200) throw new HttpException("Invalid Auth response page code ...");



                Console.WriteLine("Authentication successful\nResponse Code: {0}\nResponse Headers: {1}\n",
                    response.StatusCode, response.ResponseHeaders);
                authUtility.AwsLogOut();

                //await Task.Run(() =>
                //    {
                //         WaitAuthCode(oldCreatedDate, authUtility);
                //    })
                //    .ContinueWith(t =>
                //    {
                //        var authCode = authUtility.GetVerificationCode();
                //        Console.WriteLine("New verfication code received: {0}\nPass auth code ...\n", authCode);
                //        authUtility.LoginToAwsWithResponseCode(authCode);

                //    }).ContinueWith(t =>
                //    {
                //        response = authUtility.GetHttp();
                //        if (response.StatusCode != 200) throw new HttpException("Invalid Auth response page code ...");

                //        Console.WriteLine("Authentication successful\nResponse Code: {0}\nResponse Headers: {1}\n",
                //                           response.StatusCode, response.ResponseHeaders);
                //        authUtility.AwsLogOut();
                //    });
            }
            catch (HttpException e)
            {
                Console.WriteLine(e.Message);
                authUtility.AwsLogOut();
                Environment.Exit(-1);
            }
        }




        private void WaitAuthCode(DateTime? oldCreatedDate, AuthFacade authUtility)
        {
            try
            {
                var wait = true;
                var sw = new Stopwatch();
                sw.Start();

                do
                {
                    Console.WriteLine("Wait ...");
                    Thread.Sleep(10000); // Wait 10 secunds to get new income message to twilio

                    var newCreatedDate = authUtility.GetSmsLastCreatedDate();


                    if (sw.ElapsedMilliseconds > 60000) throw new TimeoutException("Failed to get verification code ...");
                    if (newCreatedDate == oldCreatedDate) continue;

                    wait = false;
                    Console.WriteLine("Read recerved new message");

                } while (wait);
            }
            catch (TimeoutException te)
            {
                Console.WriteLine(te.Message);
                authUtility.AwsLogOut();
                Environment.Exit(0);
            }
        }

    }
}
