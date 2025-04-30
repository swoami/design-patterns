using RemoteProxyPatternSampleContract;

namespace RemoteProxyServerSample
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
    }
}
