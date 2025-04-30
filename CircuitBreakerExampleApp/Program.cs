class Program
{
    static void Main()
    {
        var breaker = new CircuitBreaker();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            try
            {
                breaker.Execute(() =>
                {
                    Console.WriteLine("Executing service method.");

                    Thread.Sleep(1000);
                    if (random.NextDouble() < 0.3)
                        throw new Exception("Random failure!");

                    Console.WriteLine("Service method executed.");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Thread.Sleep(200);
        }
    }
}
