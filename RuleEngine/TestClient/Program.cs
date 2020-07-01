using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuleEngine;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentInfo info = new PaymentInfo() { PaymentId = 1, OrderId = 100, PaymentType = "Book",CustomerId = 1000 };
            RuleEvaluator re = new RuleEvaluator();
            re.InvokeRules(info);
        }
    }
}
