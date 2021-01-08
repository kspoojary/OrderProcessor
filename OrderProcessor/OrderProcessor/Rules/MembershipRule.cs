using OrderProcessor.Enums;

namespace OrderProcessor.Rules
{
    public class MembershipRule :IRule
    {
        private readonly IRuleAction ruleAction;
        public MembershipRule(IRuleAction ruleAction)
        {
            this.ruleAction = ruleAction;
        }
        public bool Execute(PaymentContext context)
        {
            ruleAction.ActivateMemberShip(context);
            ruleAction.SendEmail(context);
            return true;
        }

        public bool IsApplicable(PaymentContext context)
        {
            return context.Type == PaymentType.ActivateMembership;
        }
    }
}
