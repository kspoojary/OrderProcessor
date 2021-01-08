using OrderProcessor.Enums;

namespace OrderProcessor.Rules
{
    public class LearningRule : IRule
    {
        private readonly IRuleAction ruleAction;
        public LearningRule(IRuleAction ruleAction)
        {
            this.ruleAction = ruleAction;
        }
        public bool Execute(PaymentContext context)
        {
            ruleAction.AddFirstAidVideo(context);
            return true;
        }

        public bool IsApplicable(PaymentContext context)
        {
            return context.Type == PaymentType.Learning;
        }
    }
}
