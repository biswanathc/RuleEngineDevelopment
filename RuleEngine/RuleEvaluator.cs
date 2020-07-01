using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class RuleEvaluator
    {
        public void InvokeRules(PaymentInfo paymentInfo)
        {
            List<string> methodList = new List<string>();
            var qualifiedRules = EvaluateQualifyingRules(paymentInfo);
            StringBuilder sb = new StringBuilder();
            foreach(Rule rule in qualifiedRules)
            {
                sb.Append(rule.MethodName);
            }

            methodList = sb.ToString().Split(';').ToList();

            foreach(string methodName in methodList)
            {
                MethodExecutor me = new MethodExecutor();
                Type methodType = me.GetType();
                MethodInfo method = methodType.GetMethod(methodName);
                object magicValue = method.Invoke(me, new object[] { paymentInfo.PaymentId });
            }
        }

        private List<Rule> GetRuleList()
        {
            List<Rule> ruleList = new List<Rule>();
            ruleList.Add(new Rule() { RuleName = "PhysicalProduct", MethodName = "GeneratePackagingSlipShipping;GenerateCommision:" });
            ruleList.Add(new Rule() { RuleName = "Book", MethodName = "GeneratePackagingSlipRoyalty;GenerateCommision:" });
            ruleList.Add(new Rule() { RuleName = "Membership", MethodName = "ActivateMembership;SendMail:" });
            ruleList.Add(new Rule() { RuleName = "UpgradeMembership", MethodName = "UpgradeMembership;SendMail:" });
            ruleList.Add(new Rule() { RuleName = "SpecialVideo", MethodName = "FreeVideo:" });
            return ruleList;
        }

        private List<Rule> EvaluateQualifyingRules(PaymentInfo paymentInfo)
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
