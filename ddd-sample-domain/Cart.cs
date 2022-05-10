using System;
using System.Collections.Generic;
using System.Text;

namespace ddd_sample_domain
{
    public class Cart
    {
        public List<Product> Products { get; private set; }
        public List<Item> Items { get; private set; }

        public Cart()
        {
            Products = new List<Product>();
            Items = new List<Item>();
        }

        public void add(Product product)
        {
            Products.Add(product);
        }

        public override String ToString()
        {
            var cartInString = "Cart{products=[";
            foreach (var product in Products)
            {
                cartInString += product.ToString();
            }
            cartInString += "]}";
            return cartInString;
        }

        public void add(Product product, int quantity)
        {
            add(product);
            Items.Add(new Item(product, quantity));
        }

        public void remove(Product givenAProductToRemove)
        {
            Items.RemoveAll(i => i.IsSameProduct(givenAProductToRemove));
            Products.RemoveAll(p => p.HasSameName(givenAProductToRemove));
        }
    }
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
    }
}
