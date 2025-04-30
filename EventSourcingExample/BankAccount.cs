public class BankAccount
{
    private readonly List<BankAccountEvent> _eventStore = new List<BankAccountEvent>();
    public decimal Balance { get; internal set; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");

        var depositEvent = new MoneyDeposited { Amount = amount };
        Apply(depositEvent);
        _eventStore.Add(depositEvent);
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds.");

        var withdrawEvent = new MoneyWithdrawn { Amount = amount };
        Apply(withdrawEvent);
        _eventStore.Add(withdrawEvent);
    }

    private void Apply(BankAccountEvent @event)
    {
        @event.Apply(this);
    }

    public void LoadFromHistory(IEnumerable<BankAccountEvent> history)
    {
        foreach (var @event in history)
        {
            @event.Apply(this);
        }
    }

    public IEnumerable<BankAccountEvent> GetHistory() => _eventStore;
}
