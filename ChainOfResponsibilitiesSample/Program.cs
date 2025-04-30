class Program
{
    static void Main()
    {
        var customer = new Customer
        {
            PostCode = "",
            PhoneNumber = "123456789",
            EmailAddress = "invalid-email"
        };

        var validatorChain = new PostCodeValidator();
        validatorChain
            .SetNext(new PhoneNumberValidator())
            .SetNext(new EmailAddressValidator());

        validatorChain.Validate(customer);
    }
}

