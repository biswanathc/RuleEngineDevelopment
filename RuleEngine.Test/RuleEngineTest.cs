using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine;

namespace RuleEngine.Test
{
    [TestClass]
    public class RuleEngineTest
    {
        [TestMethod]
        public void TestMembershipActivation()
        {
            //Data Set Up
            PaymentInfo payment = new PaymentInfo() { PaymentType = "Membership", CustomerId = 100, OrderId = 10, PaymentId = 101 };
            PaymentRuleEngine pr = new PaymentRuleEngine();

            //Execute
            var result = pr.ProcessPayment(payment);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("MembershipActivated"));
        }

        [TestMethod]
        public void TestGenerateComission()
        {
            //Data Set Up
            PaymentInfo payment = new PaymentInfo() { PaymentType = "Book", CustomerId = 100, OrderId = 10, PaymentId = 101 };
            PaymentRuleEngine pr = new PaymentRuleEngine();

            //Execute
            var result = pr.ProcessPayment(payment);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains("CommisionGenerated"));
        }
    }
}
