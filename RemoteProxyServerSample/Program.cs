using RemoteProxyPatternSampleContract;
using System;
using System.ServiceModel;

namespace RemoteProxyServerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/CalculatorService");

            using (ServiceHost host = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(ICalculatorService), new BasicHttpBinding(), "");

                host.Open();
                Console.WriteLine("Service is running at: " + baseAddress);
                Console.WriteLine("Press ENTER to exit.");
                Console.ReadLine();
                
                host.Close();
            }
        }
    }
}
