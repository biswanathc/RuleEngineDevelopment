using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class MethodExecutor
    {
        public string GeneratePackagingSlipShipping(int paymentid)
        {
            //logic
            return "PackagingSlipShipped";
        }

        public string GenerateCommision(int paymentid)
        {
            //logic
            return "CommisionGenerated";
        }

        public string GeneratePackagingSlipRoyalty(int paymentid)
        {
            //logic
            return "PackagingSlipRoyalty";
        }

        public string ActivateMembership(int paymentid)
        {
            //logic
            return "MembershipActivated";
        }

        public string UpgradeMembership(int paymentid)
        {
            //logic
            return "MembershipUpdated";
        }

        public string SendMail(int paymentid)
        {
            //logic
            return "MailSent";
        }

        public string FreeVideo(int paymentid)
        {
            //logic
            return "FreeVideoApplied";
        }
    }
}
