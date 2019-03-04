using AwsAuthUtility.Infrastructure.Models;
using System;
using AwsAuthUtility.Infrastructure.Providers;
using AwsAuthUtility.Infrastructure.Providers.Interfaces;
using AwsAuthUtility.Infrastructure.Repository;

namespace AwsAuthUtility.Infrastructure.Classes
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
            _awsFacade.PassAccountAttrsToAws();
        }


        public string GetVerificationCode()
        {
            return _twilioFacade.ReadAccountLastSmsCode();
        }



        public void LoginToAwsWithResponseCode(string code)
        {
            _awsFacade.PassResponseAwsCode(code);
        }


        public HttpAwsResponse GetHttp()
        {
            return _awsFacade.GetAwsHttpResponse();
        }


        public void AwsLogOut()
        {
            _awsFacade.LogOut();
        }

    }
}
