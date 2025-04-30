public class EmailAddressValidator : Validator
{
    public override void Validate(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.EmailAddress) || !customer.EmailAddress.Contains("@"))
        {
            Console.WriteLine("Invalid EmailAddress!");
        }
        base.Validate(customer);
    }
}

