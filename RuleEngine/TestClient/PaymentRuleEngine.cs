using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class PaymentRuleEngine
    {
        public void InvokeRules(PaymentInfo paymentInfo)
        {
            RuleEvaluator re = new RuleEvaluator();
            List<string> methodList = new List<string>();
            var qualifiedRules = re.EvaluateQualifyingRules(paymentInfo);
            StringBuilder sb = new StringBuilder();
            foreach (Rule rule in qualifiedRules)
            {
                sb.Append(rule.MethodName);
            }

            methodList = sb.ToString().Split(';').ToList();
            var count = methodList.Count;
            methodList.RemoveAt(--count);

            foreach (string methodName in methodList)
            {
                MethodExecutor me = new MethodExecutor();
                Type methodType = me.GetType();
                System.Reflection.MethodInfo method = methodType.GetMethod(methodName);
                object magicValue = method.Invoke(me, new object[] { paymentInfo.PaymentId });
            }
        }
    }
}
