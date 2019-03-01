using AmazonRegistrator.Infrastructure.Models;

namespace AmazonRegistrator.Infrastructure.Classes
{
    public static class AccountRepository
    {
        private static Account _loadedAccount;

        public static Account LoadedAccount
        {
            get { return _loadedAccount; }
            set
            {
                if (_loadedAccount == value) return;
                _loadedAccount = value;
            }
        }
    }
}
