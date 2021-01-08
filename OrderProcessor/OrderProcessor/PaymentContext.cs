using OrderProcessor.Enums;
using System;

namespace OrderProcessor
{
    public class PaymentContext
    {
        public double Amount { get; set; }

        public PaymentType Type { get; set; }

        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }
    }
}