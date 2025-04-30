public class PostCodeValidator : Validator
{
    public override void Validate(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.PostCode))
        {
            Console.WriteLine("Invalid PostCode!");
        }
        base.Validate(customer);
    }
}

