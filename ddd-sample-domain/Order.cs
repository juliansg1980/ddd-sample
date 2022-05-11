using System;
using System.Collections.Generic;
using System.Text;

namespace ddd_sample_domain
{
    public class Order
    {
        public List<Product> Products { get; private set; }

        public Order(List<Product> products)
        {
            Products = products;
        }
    }
}
