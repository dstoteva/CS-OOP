using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class ProductsList
    {
        private List<Product> allProducts;
        public ProductsList(string[] parameters)
        {
            this.AllProducts = new List<Product>();
            for (int i = 0; i < parameters.Length; i += 2)
            {
                Product currentProduct = new Product(parameters[i], decimal.Parse(parameters[i + 1]));
                this.AllProducts.Add(currentProduct);
            }

        }
        public List<Product> AllProducts
        {
            get => this.allProducts;
            private set
            {
                this.allProducts = value;
            }
        }

        public Product GetProduct(string name)
        {
            return AllProducts.FirstOrDefault(x => x.Name == name);
        }
    }
}
