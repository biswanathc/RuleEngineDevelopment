using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class PaymentRuleEngine
    {
        /// <summary>
        /// This is entry point of rule engine.This class dynamically invokes method based on selected rules
        /// </summary>
        /// <param name="paymentInfo"></param>
        public List<string> ProcessPayment(PaymentInfo paymentInfo)
        {
            List<string> methodList = new List<string>();
            var qualifiedRules = new RuleEvaluator().EvaluateQualifyingRules(paymentInfo);
            StringBuilder sb = new StringBuilder();
            foreach (Rule rule in qualifiedRules)
            {
                sb.Append(rule.MethodName);
            }

            methodList = sb.ToString().Split(';').ToList();
            var methodCount = methodList.Count;
            methodList.RemoveAt(--methodCount);
            List<string> finalResult = new List<string>();
            //Dynamically invoking methods
            foreach (string methodName in methodList)
            {
                MethodExecutor me = new MethodExecutor();
                Type methodType = me.GetType();
                MethodInfo method = methodType.GetMethod(methodName);
                object result = method.Invoke(me, new object[] { paymentInfo.PaymentId });
                finalResult.Add(result.ToString());
            }

            return finalResult;
        }
    }
}
