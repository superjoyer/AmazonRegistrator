namespace AwsAuthUtility.Infrastructure.Providers.Interfaces
{
    public interface IProvider<T> where T :  class
    {
        T Provide();
    }
}
