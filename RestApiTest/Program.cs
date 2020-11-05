using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace RestApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost selfHost = new ServiceHost(typeof(Service1));
            selfHost.Open();
            Console.WriteLine("Service Open");
            Console.ReadKey();
            selfHost.Close();
        }
    }
}
