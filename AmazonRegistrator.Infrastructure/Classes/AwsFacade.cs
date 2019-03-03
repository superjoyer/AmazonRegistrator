using AmazonRegistrator.Infrastructure.Interfaces;
using AmazonRegistrator.Infrastructure.Models;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Net;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class AwsFacade
    {
        private readonly IProvider<string> _awsLinkProvider;
        private readonly AwsLogginer _awsHtmlSender;
        private RemoteWebDriver _driver;


        public AwsFacade(IProvider <string> awsLinkProvider)
        {
            _awsLinkProvider = awsLinkProvider;
            _awsHtmlSender = new AwsLogginer();
            Init();
        }


        private void Init()
        {
            string pathTowebDriver = @"Web\chromedriver.exe";

            if (!File.Exists(pathTowebDriver))
                throw new FileNotFoundException("Can't find web driver utility (path: ../Web/[webdriver].exe) ...");

            _driver = new ChromeDriver(@"Web\");

        }






        public string PassAccountAttrsToAWS()
        {

            var awsUrl = _awsLinkProvider.Provide();

            try
            {
               _driver.Navigate().GoToUrl(awsUrl);
               _awsHtmlSender.PutAccountAttrsToLoginForm(_driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }

            return _driver.Url;
        }




        public void PassResponcedAWSCode(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new InvalidDataException("Invalid autentificate code ...");
            if (_driver == null) throw new NullReferenceException("Web driver not initialize ...");
            _awsHtmlSender.PutCodeToLoginForm(_driver, code);
        }




        public HttpAwsResponse GetAwsHttpResponse()
        {
            if (_driver == null) throw new NullReferenceException("Web driver not initialize ...");
            var httpCreator = new HttpCreator();
            var response = httpCreator.GetHttpResponseAsync(_driver.Url);
            return response.Result;
        }
    }
}
