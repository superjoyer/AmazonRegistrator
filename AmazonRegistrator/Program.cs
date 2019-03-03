using System;

namespace AmazonRegistrator.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var authUtility = new AuthUtility();
            authUtility.Autentificate();

            Console.ReadKey();
        }
    }
}
