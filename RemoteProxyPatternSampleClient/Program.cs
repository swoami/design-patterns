using RemoteProxyPatternSampleContract;
using System;
using System.ServiceModel;

class Program
{
    static void Main(string[] args)
    {
        ICalculatorService calculator = GetCalculatorProxy();

        try
        {
            int sum = calculator.Add(5, 7);
            int diff = calculator.Subtract(10, 4);

            Console.WriteLine($"Add(5, 7) = {sum}");
            Console.WriteLine($"Subtract(10, 4) = {diff}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static ICalculatorService GetCalculatorProxy()
    {
        var binding = new BasicHttpBinding();
        var endpoint = new EndpointAddress("http://localhost:8080/CalculatorService");
        var factory = new ChannelFactory<ICalculatorService>(binding, endpoint);

        return factory.CreateChannel();
    }
}