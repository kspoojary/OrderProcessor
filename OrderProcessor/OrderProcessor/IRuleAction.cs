using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessor
{
    public interface IRuleAction
    {
        bool GeneratePakagingSlip(PaymentContext context);

        bool DuplicatePackagingSlip(PaymentContext context);

        bool ActivateMemberShip(PaymentContext context);

        bool UppgradeMemberShip(PaymentContext context);

        bool SendEmail(PaymentContext context);

        bool AddFirstAidVideo(PaymentContext context);

        bool GenerateCommisionPayment(PaymentContext context);
    }
}
