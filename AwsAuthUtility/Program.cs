using System;

namespace AwsAuthUtility.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var authUtility = new AuthUtility();
            authUtility.Auth();
            Console.ReadKey();
        }
    }
}
