using System;
using System.Collections.Generic;

namespace ddd_sample_domain
{
    public class Item
    {
        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public Item(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Boolean IsSameProduct(Product toCompare)
        {
            return Product.HasSameName(toCompare);
        }

        internal IEnumerable<Product> GetProductsToOrder()
        {
            var productsToOrder = new List<Product>();
            for(int i = 0; i < Quantity; i ++)
            {
                productsToOrder.Add(Product);
            }
            return productsToOrder;
        }
    }
}
