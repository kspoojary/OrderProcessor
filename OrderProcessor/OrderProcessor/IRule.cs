namespace OrderProcessor
{
    public interface IRule
    {
        bool IsApplicable(PaymentContext context);

        bool Execute(PaymentContext context);
    }
}
