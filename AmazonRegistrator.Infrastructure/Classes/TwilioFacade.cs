using AmazonRegistrator.Infrastructure.Interfaces;
using AmazonRegistrator.Infrastructure.Models;
using System;
using System.Linq;
using Twilio;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class TwilioFacade
    {
        private readonly IRemoteReader<TwilioContent> _twilioReader;
        private readonly IParser _codeParser;

        public TwilioFacade()
        {
            _twilioReader = new TwilioSmsReader();
            _codeParser = new CodeParser();
        }

        private bool Login()
        {
            bool isLogin = false;
            try
            {
                var accountSid = AccountRepository.LoadedAccount.AccountSID;
                var authToken = AccountRepository.LoadedAccount.AuthToken;
                TwilioClient.Init(accountSid, authToken);
                isLogin = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return isLogin;
        }



        public int ReadAccountLastSmsCode()
        {
            if (!Login()) throw new Exception("Twilio autentification error.Unidentified user ...");

            var accountSmsList = _twilioReader.ReadAsList();
            TwilioContent smsText = accountSmsList.LastOrDefault();

            var rawCode = _codeParser.Parse(smsText.Body);
            int.TryParse(rawCode, out int resultCode);
            return resultCode;
        }
    }
}
