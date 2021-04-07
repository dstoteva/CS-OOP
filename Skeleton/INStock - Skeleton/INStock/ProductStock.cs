using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private IProduct[] products;
        private const int initialSize = 4;
        public ProductStock()
        {
            this.products = new IProduct[initialSize];
        }
        public int Count { get; set; }
        public int Capacity
        {
            get => this.products.Length;
        }

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new InvalidOperationException();
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (products[i].CompareTo(product) == 0)
                {
                    products[i].Quantity += product.Quantity;
                    return;
                }
            }

            if (products.Length == Count)
            {
                this.Resize();
            }
            this.products[this.Count++] = product;
        }

        public bool Contains(IProduct product)
        {
            return this.Any(x => x.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (this.Count < index + 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return this[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            if (!this.Any(x => x.Label == label))
            {
                throw new ArgumentException();
            }
            return this.FirstOrDefault(x => x.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.products[i] == product)
                {
                    this.products[i] = null;

                    this.Reorder(i);

                    this.Count--;

                    if (this.Capacity / 2 == this.Count)
                    {
                        this.Shrink();
                    }

                    return true;
                }
            }
            return false;
        }
        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IProduct this[int index]
        {
            get
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.products[index];
            }
            set
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                this.products[index] = value;
            }
        }

        private void Resize()
        {
            var tempArray = new IProduct[this.Capacity * 2];
            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.products[i];
            }
            this.products = tempArray;
        }

        private void Reorder(int i)
        {
            for (int j = i; j < this.Count - 1; j++)
            {
                this.products[j] = this.products[j + 1];
            }
        }
        private void Shrink()
        {
            var tempArray = new IProduct[this.Capacity / 2];
            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.products[i];
            }
            this.products = tempArray;
        }
    }
}
