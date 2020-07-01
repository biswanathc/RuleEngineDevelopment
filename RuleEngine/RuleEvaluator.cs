using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class RuleEvaluator
    {
        public void InvokeRules()
        {

        }

        private void GetRuleList()
        {
            List<Rule> ruleList = new List<Rule>();
            ruleList.Add(new Rule() { RuleName = "PhysicalProduct", MethodName = "GeneratePackagingSlipShipping;GenerateCommision" });
            ruleList.Add(new Rule() { RuleName = "Book", MethodName = "GeneratePackagingSlipRoyalty;GenerateCommision" });
            ruleList.Add(new Rule() { RuleName = "Membership", MethodName = "ActivateMembership;SendMail" });
            ruleList.Add(new Rule() { RuleName = "UpgradeMembership", MethodName = "UpgradeMembership;SendMail" });
            ruleList.Add(new Rule() { RuleName = "SpecialVideo", MethodName = "FreeVideo" });
        }
    }
}
