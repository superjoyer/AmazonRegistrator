using AmazonRegistrator.Infrastructure.Interfaces;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public class AWSHttpFacade 
    {
        private readonly IConnect _awsConnector;

        public AWSHttpFacade(IConnect awsConnector)
        {
            _awsConnector = awsConnector;
        }


        public void SendPost()
        {
            _awsConnector.Login();
        }



    }
}
