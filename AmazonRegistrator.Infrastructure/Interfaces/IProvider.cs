using AmazonRegistrator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonRegistrator.Infrastructure.Interfaces
{
    public interface IProvider<T> where T :  class
    {
        T Provide();
    }
}
