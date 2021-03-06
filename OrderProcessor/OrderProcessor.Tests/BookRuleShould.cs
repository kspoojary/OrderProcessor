﻿using Moq;
using OrderProcessor.Enums;
using OrderProcessor.Rules;
using System;
using System.Collections.Generic;
using Xunit;

namespace OrderProcessor.Tests
{
    public class BookRuleShould
    {
        [Fact]
        public void VerifyDuplicatePackagingSlipCalledOnce()
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
            mockPayment.Setup(m => m.DuplicatePackagingSlip(It.IsAny<PaymentContext>())).Returns(true);
            var rules = new List<IRule>()
            {
                new PhysicalProductRule(mockPayment.Object),
                new LearningRule(mockPayment.Object),
                new BookRule(mockPayment.Object)
            };
            RuleEngine ruleEngine = new RuleEngine(rules);

            #endregion
            #region Act
            ruleEngine.Execute(payment);
            #endregion

            #region Assert
            mockPayment.Verify(m => m.DuplicatePackagingSlip(It.IsAny<PaymentContext>()), Times.Once);
            #endregion
        }

        [Fact]
        public void VerifyGenerateCommisionPaymentCalledOnce()
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
            mockPayment.Setup(m => m.GenerateCommisionPayment(It.IsAny<PaymentContext>())).Returns(true);
            var rules = new List<IRule>()
            {
                 new PhysicalProductRule(mockPayment.Object),
                new LearningRule(mockPayment.Object),
                new BookRule(mockPayment.Object)
            };
            RuleEngine ruleEngine = new RuleEngine(rules);

            #endregion
            #region Act
            ruleEngine.Execute(payment);
            #endregion

            #region Assert
            mockPayment.Verify(m => m.GenerateCommisionPayment(It.IsAny<PaymentContext>()), Times.Once);
            #endregion
        }

        [Fact]
        public void VerifyGenerateCommisionPaymentCalledNeverIfRuleIsNotApplicable()
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
            mockPayment.Setup(m => m.GenerateCommisionPayment(It.IsAny<PaymentContext>())).Returns(true);
            var rules = new List<IRule>()
            {
                new BookRule(mockPayment.Object)
            };
            RuleEngine ruleEngine = new RuleEngine(rules);
            #endregion

            #region Act
            ruleEngine.Execute(payment);
            #endregion

            #region Assert
            mockPayment.Verify(m => m.GenerateCommisionPayment(It.IsAny<PaymentContext>()), Times.Never);
            #endregion
        }
    }
}
