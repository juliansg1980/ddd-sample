using System;
using System.Collections.Generic;
using System.Text;

namespace ddd_sample_domain
{
    public class Price
    {
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }

        public Price(string currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }
    }
}
