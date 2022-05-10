using ddd_sample_domain;
using FluentAssertions;
using NUnit.Framework;

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
    }
}
