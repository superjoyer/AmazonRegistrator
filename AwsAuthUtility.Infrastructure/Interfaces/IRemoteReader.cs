using System.Collections.Generic;

namespace AwsAuthUtility.Infrastructure.Interfaces
{
    public interface IRemoteReader<T> where T : class 
    {
        T Read();

        List<T> ReadAsList();
    }
}
