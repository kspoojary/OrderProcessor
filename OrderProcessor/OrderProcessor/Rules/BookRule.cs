using OrderProcessor.Enums;

namespace OrderProcessor.Rules
{
    public class BookRule : IRule
    {
        private readonly IRuleAction ruleAction;
        public BookRule(IRuleAction ruleAction)
        {
            this.ruleAction = ruleAction;
        }
        public bool Execute(PaymentContext context)
        {
            ruleAction.DuplicatePackagingSlip(context);
            ruleAction.GenerateCommisionPayment(context);
            return true;
        }

        public bool IsApplicable(PaymentContext context)
        {
            return context.Type == PaymentType.Book;
        }
    }
}
