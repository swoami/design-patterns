public class PhoneNumberValidator : Validator
{
    public override void Validate(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
        {
            Console.WriteLine("Invalid PhoneNumber!");
        }
        base.Validate(customer);
    }
}

