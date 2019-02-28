using AmazonRegistrator.Infrastructure.Interfaces;
using AmazonRegistrator.Infrastructure.Models;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class AWSHttpFacade 
    {
        private readonly IProvider<Account> _accountProvider;
        private readonly IConnect _awsConnector;
        private Account _account;

        //private readonly TwilioRestClient client;

        public AWSHttpFacade(IProvider<Account> accountProvider, IConnect awsConnector)
        {
            _accountProvider = accountProvider;
            _awsConnector = awsConnector;
           
            LoadAccount();
        }

        private void LoadAccount()
        {
            _account = _accountProvider.Provide();
        }


        public void SendPost()
        {
            _awsConnector.Login();
        }



    }
}
