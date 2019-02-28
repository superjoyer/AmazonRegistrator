using AmazonRegistrator.Infrastructure.Interfaces;
using AmazonRegistrator.Infrastructure.Models;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class AccountProvider : IProvider<Account>
    {
        private readonly ConfigFacade _configFacade;

        public AccountProvider()
        {
            _configFacade = new ConfigFacade();
        }


        public Account Provide()
        {
            string accountSID = _configFacade.LoadAccountSID();
            string authToken = _configFacade.LoadAuthToken();
            string email = _configFacade.LoadAwsEmail();
            string password = _configFacade.LoadAwsPass();
            string phoneTo = _configFacade.LoadPhoneTo();




            return new Account
            {
                AccountSID = accountSID,
                AuthToken = authToken,
                Email = email,
                Password = password,
                PhoneTo = phoneTo
            };
        }
    }
}
