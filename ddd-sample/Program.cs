using ddd_sample_domain;
using System;

namespace ddd_sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();
            var applePencil = new Product("Apple Pencil");
            cart.add(applePencil);

            Console.WriteLine("Cart = " + cart);
            var products = cart.Products;

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("products = ");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
