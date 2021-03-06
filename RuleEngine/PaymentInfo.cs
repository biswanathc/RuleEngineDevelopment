﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    /// <summary>
    /// This class hold properties of a payment object
    /// </summary>
    public class PaymentInfo
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string PaymentType { get; set; }
    }
}
