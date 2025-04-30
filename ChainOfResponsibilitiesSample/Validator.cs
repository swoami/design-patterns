public abstract class Validator
{
    private Validator _next;

    public Validator SetNext(Validator next)
    {
        _next = next;
        return next;
    }

    public virtual void Validate(Customer customer)
    {
        _next?.Validate(customer);
    }
}

