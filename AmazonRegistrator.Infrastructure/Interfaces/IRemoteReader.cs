using System.Collections.Generic;

namespace AmazonRegistrator.Infrastructure.Interfaces
{
    public interface IRemoteReader<T> where T : class 
    {
        T Read();

        List<T> ReadAsList();
    }
}
