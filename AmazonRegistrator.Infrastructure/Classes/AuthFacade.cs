using AmazonRegistrator.Infrastructure.Interfaces;
using AmazonRegistrator.Infrastructure.Models;
using System;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class AuthFacade
    {
        private readonly IProvider<Account> _accountProvider;
        private readonly IProvider<string> _awsLinkProvider;
        private readonly AwsFacade _awsFacade;
        private readonly TwilioFacade _twilioFacade;           
       
        


        public AuthFacade()
        {
            _accountProvider = new AccountProvider();
            _awsLinkProvider = new AwsAuthLinkProvider();
           
            _awsFacade = new AwsFacade(_awsLinkProvider);
            _twilioFacade = new TwilioFacade();

            LoadAccount();
        }


        private void LoadAccount()
        {
            AccountRepository.CurrentAccount = _accountProvider.Provide();
        }


        public DateTime? GetSmsLastCreatedDate()
        {
            return _twilioFacade.ReadAccountSmsLastCreatedDate();
        }




        public void LoginToAwsWithAccountAttrs()
        {
            _awsFacade.PassAccountAttrsToAWS();
        }


        public string GetVerificateCode()
        {
            return _twilioFacade.ReadAccountLastSmsCode();
        }



        public void LoginToAwsWithResponcedCode(string code)
        {
            _awsFacade.PassResponcedAWSCode(code);
        }


        public HttpAwsResponse GetHttp()
        {
            return _awsFacade.GetAwsHttpResponse();
        }

    }
}
