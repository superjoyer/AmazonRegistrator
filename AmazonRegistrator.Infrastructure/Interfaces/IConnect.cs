using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonRegistrator.Infrastructure.Interfaces
{
    public interface IConnect
    {
        void Login(string userName = null, string password = null);
    }
}
