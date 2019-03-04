namespace AwsAuthUtility.Infrastructure.Interfaces
{
    public interface IConnect
    {
        void Login(string userName = null, string password = null);
    }
}
