public class CircuitBreaker
{
    private CircuitBreakerState _state = CircuitBreakerState.Closed;
    private DateTime _lastFailureTime;
    private readonly TimeSpan _openTimeout = TimeSpan.FromSeconds(2);
    private int _successCount = 0;
    private readonly int _successThreshold = 2;

    public void Execute(Action action)
    {
        switch (_state)
        {
            case CircuitBreakerState.Open:
                if (DateTime.UtcNow - _lastFailureTime > _openTimeout)
                {
                    Console.WriteLine("Timeout passed. Moving to Half-Open.");
                    _state = CircuitBreakerState.HalfOpen;
                }
                else
                {
                    Console.WriteLine("Circuit is Open. Failing fast.");
                    throw new InvalidOperationException("Circuit is open.");
                }
                break;

            case CircuitBreakerState.HalfOpen:
                TryHalfOpen(action);
                return;
        }

        TryClosed(action);
    }

    private void TryClosed(Action action)
    {
        try
        {
            action();
            Console.WriteLine("Action succeeded.");
        }
        catch
        {
            Console.WriteLine("Action failed. Moving to Open state.");
            _state = CircuitBreakerState.Open;
            _lastFailureTime = DateTime.UtcNow;
            throw;
        }
    }

    private void TryHalfOpen(Action action)
    {
        try
        {
            action();
            _successCount++;
            Console.WriteLine($"Half-Open: success count = {_successCount}");

            if (_successCount >= _successThreshold)
            {
                Console.WriteLine("Success threshold reached. Moving to Closed.");
                _state = CircuitBreakerState.Closed;
                _successCount = 0;
            }
        }
        catch
        {
            Console.WriteLine("Half-Open: action failed. Moving back to Open.");
            _state = CircuitBreakerState.Open;
            _lastFailureTime = DateTime.UtcNow;
            _successCount = 0;
            throw;
        }
    }
}
