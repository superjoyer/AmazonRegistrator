using AmazonRegistrator.Infrastructure.Models;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public static class AccountRepository
    {
        private static Account _currentAccount;

        public static Account CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                if (_currentAccount == value) return;
                _currentAccount = value;
            }
        }
    }
}
