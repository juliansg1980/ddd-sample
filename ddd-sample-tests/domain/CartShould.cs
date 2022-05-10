﻿using ddd_sample_domain;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using NSubstitute;
using System;
using System.Collections.Generic;

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
            cart.Items.Should().HaveCount(1);
            cart.Items.First().Should().BeEquivalentTo(new Item(givenAProduct, givenAnyQuantity));
        }

        [Test]
        public void remove_a_product()
        {
            var givenAProductToRemove = new Product("productToRemove");
            var givenAnotherProduct = new Product("anotherProduct");
            var cart = new Cart();
            cart.add(givenAProductToRemove, 2);
            cart.add(givenAnotherProduct, 2);
            cart.add(givenAProductToRemove, 5);

            cart.remove(givenAProductToRemove);

            var expectedItems = new List<Item>() { new Item(givenAnotherProduct, 2)};
            cart.Items.Should().BeEquivalentTo(expectedItems);
            var expectedProducts = new List<Product>() { givenAnotherProduct };
            cart.Products.Should().BeEquivalentTo(expectedProducts);
        }
    }
}
