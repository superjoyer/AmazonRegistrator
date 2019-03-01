using AmazonRegistrator.Infrastructure.Interfaces;
using AmazonRegistrator.Infrastructure.Models;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class UtilityFacade
    {
        private readonly IProvider<Account> _accountProvider;
        private readonly IConnect _awsConnector;
        
        private readonly AWSHttpFacade _awsFacade;
        private readonly TwilioFacade _twilioFacade;           
       
        


        public UtilityFacade()
        {
            _accountProvider = new AccountProvider();
            _awsConnector = new AwsConnector();
           
            _awsFacade = new AWSHttpFacade(_awsConnector);
            _twilioFacade = new TwilioFacade();

            LoadAccount();
        }


        private void LoadAccount()
        {
            AccountRepository.LoadedAccount = _accountProvider.Provide();
        }




        public void LoginToAws()
        {
            _awsFacade.SendPost();
        }


        public void GetCode()
        {
            var code = _twilioFacade.ReadAccountLastSmsCode();
        }
    }
}
