using AwsAuthUtility.Infrastructure.Models;

namespace AwsAuthUtility.Infrastructure.Repository
{
    public static class AccountRepository
    {
        private static Account _currentAccount;

        public static Account CurrentAccount
        {
            get => _currentAccount;
            set
            {
                if (_currentAccount != null && _currentAccount == value) return;
                _currentAccount = value;
            }
        }
    }
}
