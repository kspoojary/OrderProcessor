using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderProcessor
{
    public class RuleEngine
    {
        private IEnumerable<IRule> rules;
        public RuleEngine(IEnumerable<IRule> rules)
        {
            this.rules = rules;
        }

        public void Execute(PaymentContext context)
        {
            var applicableRules = rules.Where(rule => rule.IsApplicable(context)).ToList();
            if(applicableRules.Any())
            {
                applicableRules.ForEach(rule => rule.Execute(context));
            }
        }
    }
}
