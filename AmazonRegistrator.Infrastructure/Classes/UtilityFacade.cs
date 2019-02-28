using AmazonRegistrator.Infrastructure.Interfaces;
using AmazonRegistrator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class UtilityFacade
    {
        private readonly IProvider<Account> _accountProvider;
        private readonly IConnect _awsConnector;
        private readonly AWSHttpFacade _awsFacade;


        public UtilityFacade()
        {
            _accountProvider = new AccountProvider();
            _awsConnector = new AwsConnector();
            _awsFacade = new AWSHttpFacade(_accountProvider, _awsConnector);

        }





        public void Login()
        {
            _awsFacade.SendPost();
        }

        public void GetCode()
        {

        }
    }
}
