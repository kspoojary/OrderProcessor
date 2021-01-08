using OrderProcessor.Enums;

namespace OrderProcessor.Rules
{
    public class PhysicalProductRule : IRule
    {
        private readonly IRuleAction ruleAction;
        public PhysicalProductRule(IRuleAction ruleAction)
        {
            this.ruleAction = ruleAction;
        }
        public bool Execute(PaymentContext context)
        {
            ruleAction.GeneratePakagingSlip(context);
            ruleAction.GenerateCommisionPayment(context);
            return true;
        }

        public bool IsApplicable(PaymentContext context)
        {
            return context.Type == PaymentType.PhysicalProduct;
        }
    }
}
