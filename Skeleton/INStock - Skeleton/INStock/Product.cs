using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Label
        {
            get => this.label;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.label = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return this.Label.CompareTo(other.Label);
        }
    }
}
