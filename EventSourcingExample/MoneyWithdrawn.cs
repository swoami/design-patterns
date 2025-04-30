public class MoneyWithdrawn : BankAccountEvent
{
    public decimal Amount { get; set; }

    public override void Apply(BankAccount account)
    {
        account.Balance -= Amount;
    }
}
