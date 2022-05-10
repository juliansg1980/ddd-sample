using ddd_sample_domain;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using NSubstitute;
using System;

namespace ddd_sample_tests.domain
{
    [TestFixture]
    internal class CartShould
    {
        [Test]
        public void has_empty_products()
        {
            var cart = new Cart();

            cart.Products.Should().BeEmpty();
        }

        [Test]
        public void add_a_product()
        {
            var givenAProduct = new Product("anyName");
            var cart = new Cart();

            cart.add(givenAProduct);

            cart.Products.Should().HaveCount(1);
            cart.Products.First().Should().Be(givenAProduct);
        }

        [Test]
        public void get_cart_as_a_string()
        {
            var givenAProduct = Substitute.For<Product>("");
            givenAProduct.ToString().Returns("anyProductInText");

            var cart = new Cart();
            cart.add(givenAProduct);

            cart.ToString().Should().Be("Cart{products=[anyProductInText]}");
        }

        [Test]
        public void add_a_product_with_quantity()
        {
            var givenAProduct = new Product("anyName");
            var cart = new Cart();
            var givenAnyQuantity = 2;

            cart.add(givenAProduct, givenAnyQuantity);

            cart.Products.Should().HaveCount(1);
            cart.Products.First().Should().Be(givenAProduct);
            cart.ProductsWithQuantities.Should().HaveCount(1);
            cart.ProductsWithQuantities.First().Should().BeEquivalentTo(Tuple.Create(givenAProduct, givenAnyQuantity));
        }
    }
}
