public class MoneyDeposited : BankAccountEvent
{
    public decimal Amount { get; set; }

    public override void Apply(BankAccount account)
    {
        account.Balance += Amount;
    }
}
