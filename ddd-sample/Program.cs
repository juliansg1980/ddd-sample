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
            cart.add(applePencil, 2);
            var sonyWirelessHeadPhone = new Product("Sony Wireless headphone");
            cart.add(sonyWirelessHeadPhone);
            //cart.remove(applePencil);

            Console.WriteLine("Cart = " + cart);
            var products = cart.Products;

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("products = " + cart.ToString());
            Console.WriteLine("----------------------------------------");

            cart.checkOut();
        }
    }
}
