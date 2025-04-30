class Program
{
    static void Main()
    {
        var account = new BankAccount();

        account.Deposit(100);
        account.Withdraw(30);
        account.Deposit(50);

        Console.WriteLine($"Current Balance: {account.Balance}");

        Console.WriteLine("\nEvent History:");
        foreach (var @event in account.GetHistory())
        {
            Console.WriteLine($"- {@event.GetType().Name} at {@event.Timestamp}");
        }
        
        var restoredAccount = new BankAccount();
        restoredAccount.LoadFromHistory(account.GetHistory());

        Console.WriteLine($"\nRestored Balance: {restoredAccount.Balance}");
    }
}