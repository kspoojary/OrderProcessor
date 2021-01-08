using Moq;
using OrderProcessor.Enums;
using OrderProcessor.Rules;
using System;
using System.Collections.Generic;
using Xunit;

namespace OrderProcessor.Tests
{
    public class LearningRuleShould 
    {
        [Fact]
        public void VerifyAddFirstAidVideoCalledOnce()
        {
            #region Arrange
            PaymentContext payment = new PaymentContext()
            {
                Amount = 1000,
                Type = PaymentType.Learning,
                CustomerId = Guid.NewGuid(),
                OrderId = Guid.NewGuid(),
            };
            var mockPayment = new Mock<IRuleAction>();
            mockPayment.Setup(m => m.AddFirstAidVideo(It.IsAny<PaymentContext>())).Returns(true);
            var rules = new List<IRule>()
            {
                new LearningRule(mockPayment.Object)
            };
            RuleEngine ruleEngine = new RuleEngine(rules);

            #endregion
            #region Act
            ruleEngine.Execute(payment);
            #endregion

            #region Assert
            mockPayment.Verify(m => m.AddFirstAidVideo(It.IsAny<PaymentContext>()), Times.Once);
            #endregion
        }

        [Fact]
        public void VerifyAddFirstAidVideoCalledNeverIfRuleIsNotApplicable()
        {
            #region Arrange
            PaymentContext payment = new PaymentContext()
            {
                Amount = 1000,
                Type = PaymentType.Book,
                CustomerId = Guid.NewGuid(),
                OrderId = Guid.NewGuid(),
            };
            var mockPayment = new Mock<IRuleAction>();
            mockPayment.Setup(m => m.AddFirstAidVideo(It.IsAny<PaymentContext>())).Returns(true);
            var rules = new List<IRule>()
            {
                new LearningRule(mockPayment.Object)
            };
            RuleEngine ruleEngine = new RuleEngine(rules);

            #endregion
            #region Act
            ruleEngine.Execute(payment);
            #endregion

            #region Assert
            mockPayment.Verify(m => m.AddFirstAidVideo(It.IsAny<PaymentContext>()), Times.Never);
            #endregion
        }
    }
}
