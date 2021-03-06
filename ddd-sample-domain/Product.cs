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

        public Product(String name, Price price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Price Price { get; set; }

        public virtual new String ToString()
        {
            return "Product{" +
                    "name='" + Name + '\'' +
                    '}';
        }

        public Boolean HasSameName(Product toCompare)
        {
            return Name.Equals(toCompare.Name);
        }
    }
}
