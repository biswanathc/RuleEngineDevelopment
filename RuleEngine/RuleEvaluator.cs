using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    /// <summary>
    /// This class contains methods that evaluates rule
    /// </summary>
    public class RuleEvaluator
    {
        /// <summary>
        /// Getting list of static rules
        /// </summary>
        /// <returns>List of all rules</returns>
        private List<Rule> GetRuleList()
        {
            List<Rule> ruleList = new List<Rule>();
            ruleList.Add(new Rule() { RuleName = "PhysicalProduct", MethodName = "GeneratePackagingSlipShipping;GenerateCommision;" });
            ruleList.Add(new Rule() { RuleName = "Book", MethodName = "GeneratePackagingSlipRoyalty;GenerateCommision;" });
            ruleList.Add(new Rule() { RuleName = "Membership", MethodName = "ActivateMembership;SendMail;" });
            ruleList.Add(new Rule() { RuleName = "UpgradeMembership", MethodName = "UpgradeMembership;SendMail;" });
            ruleList.Add(new Rule() { RuleName = "SpecialVideo", MethodName = "FreeVideo;" });
            return ruleList;
        }

        /// <summary>
        /// Evauluate payment is qualified for which rule(s)
        /// </summary>
        /// <param name="paymentInfo">PaymentInfo</param>
        /// <returns>List of qualified rules</returns>
        public List<Rule> EvaluateQualifyingRules(PaymentInfo paymentInfo)
        {
            var initialRuleList = GetRuleList();
            var ruleList = new List<Rule>();
            foreach(Rule rule in initialRuleList)
            {
                //Rule Matching Condition assumed
                if(rule.RuleName == paymentInfo.PaymentType)
                {
                    ruleList.Add(rule);
                }
            }
            return ruleList;
        }

    }
}
