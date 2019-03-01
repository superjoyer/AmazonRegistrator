using AmazonRegistrator.Infrastructure.Classes;
using System;

namespace AmazonRegistrator.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var utility = new UtilityFacade();
            //utility.LoginToAws();

            utility.GetCode();


            //Process.Start("http://www.google.com");
            Console.ReadKey();
        }
    }
}
