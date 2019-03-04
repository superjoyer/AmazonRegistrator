using AwsAuthUtility.Infrastructure.Interfaces;
using AwsAuthUtility.Infrastructure.Models;
using System;
using System.Linq;
using AwsAuthUtility.Infrastructure.Parsers;
using AwsAuthUtility.Infrastructure.Parsers.Interfaces;
using AwsAuthUtility.Infrastructure.Repository;
using AwsAuthUtility.Infrastructure.Twilio;
using Twilio;

namespace AwsAuthUtility.Infrastructure.Classes
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
                var accountSid = AccountRepository.CurrentAccount.AccountSID;
                var authToken = AccountRepository.CurrentAccount.AuthToken;

                if (string.IsNullOrEmpty(accountSid)) throw new ArgumentNullException("Undefined Account SID ...");
                if (string.IsNullOrEmpty(authToken)) throw new ArgumentNullException("Undefined Auth Token ...");

                TwilioClient.Init(accountSid, authToken);
                isLogin = true;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

            return isLogin;
        }



        public string ReadAccountLastSmsCode()
        {
            if (!Login()) throw new Exception("Twilio autentification error. Unidentified user ...");

            var accountSmsList = _twilioReader.ReadAsList();
            TwilioContent smsText = accountSmsList.LastOrDefault();
            var resultCode = _codeParser.Parse(smsText?.Body);
            return resultCode;
        }



        public DateTime? ReadAccountSmsLastCreatedDate()
        {
            if (!Login()) throw new Exception("Twilio autentification error.Unidentified user ...");
            var accountSmsList = _twilioReader.ReadAsList();
            TwilioContent lastSms = accountSmsList.LastOrDefault();

            return lastSms.DateCreated;
        }
    }
}
