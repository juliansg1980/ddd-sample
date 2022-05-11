using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ddd_sample_domain
{
    public class Cart
    {
        public List<Product> Products { get; private set; }
        public List<Item> Items { get; protected set; }
        public List<string> RemovalHistory { get; private set; }
        public Order Order { get; private set; }
        public bool IsCheckOut { get; private set; }

        public Cart()
        {
            Products = new List<Product>();
            Items = new List<Item>();
            RemovalHistory = new List<string>();
        }

        public void add(Product product)
        {
            if (!Products.Any(p => p.HasSameName(product)))
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
            add(new Item(product, quantity));
        }

        public void remove(Product givenAProductToRemove)
        {
            Products.Where(p => p.HasSameName(givenAProductToRemove)).ToList().ForEach(p => RemovalHistory.Add(p.Name));
            Items.RemoveAll(i => i.IsSameProduct(givenAProductToRemove));
            Products.RemoveAll(p => p.HasSameName(givenAProductToRemove));
        }

        public void add(Item cartItem)
        {
            add(cartItem.Product);
            Items.Add(cartItem);
        }

        public void checkOut()
        {
            var productsToOrder = new List<Product>();
            foreach (var item in Items)
            {
                productsToOrder.AddRange(item.GetProductsToOrder());
            }
            Order = new Order(productsToOrder);
            IsCheckOut = true;
        }
    }
}
