using System;
using System.Collections.Generic;
using System.Text;

namespace ddd_sample_domain
{
    public class Cart
    {
        public List<Product> Products { get; private set; }

        public Cart()
        {
            Products = new List<Product>();
        }

        public void add(Product product)
        {
            Products.Add(product);
        }

        public override String ToString()
        {
            return "Cart{" +
                    "products=" + Products +
                    '}';
        }
    }
}
