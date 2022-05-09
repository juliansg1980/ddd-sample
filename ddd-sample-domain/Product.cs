using System;

namespace ddd_sample_domain
{
    public class Product
    {
        public String Name { get; private set; }

        public Product(String name)
        {
            this.Name = name;
        }

        public override String ToString()
        {
            return "Product{" +
                    "name='" + Name + '\'' +
                    '}';
        }
    }
}
