public abstract class BankAccountEvent
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public abstract void Apply(BankAccount account);
}
