namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    public class ProductStockTests
    {
        private IProductStock productStock;
        private Product dummyProduct;
        [SetUp]
        public void Setup()
        {
            this.productStock = new ProductStock();
            this.dummyProduct = new Product("SSD", 12.34m, 4);
        }
        [Test]
        public void ConstructorShouldInitializeArray()
        {
            var expectedValue = 4;
            Assert.AreEqual(expectedValue, this.productStock.Capacity);

        }
        [Test]
        public void AddMethodShouldAddSuccessfully()
        {
            productStock.Add(this.dummyProduct);

            var expectedValue = 1;

            Assert.AreEqual(expectedValue, productStock.Count);
        }
        [Test]
        public void AddShouldResizeWhenCountIsEqualToArrayLength()
        {
            var products = new[]
            {
                new Product("Test1", 12, 12),
                new Product("Test2", 12, 12),
                new Product("Test3", 12, 12),
                new Product("Test4", 12, 12),
                new Product("Test5", 12, 12)
            };
            foreach (var product in products)
            {
                this.productStock.Add(product);
            }
            var expectedValue = 8;

            Assert.AreEqual(expectedValue, this.productStock.Capacity);
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.productStock.Add(null));
        }
        [Test]
        public void SetInvalidIndexShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.productStock
            [this.productStock.Capacity + 2] = this.dummyProduct);
        }
        [Test]
        public void SetIndexShouldSetSuccessfully()
        {
            this.productStock[0] = this.dummyProduct;

            Assert.AreSame(this.dummyProduct, this.productStock[0]);
        }
        [Test]
        public void GetIndexShouldGetSuccessfully()
        {
            this.productStock.Add(this.dummyProduct);
            var product = this.productStock[0];

            Assert.AreSame(dummyProduct, product);
        }
        [Test]
        public void GetInvalidIndexShouldThrowIndexOutOfRangeException()
        {
            this.productStock.Add(this.dummyProduct);
            IProduct product = null;

            Assert.Throws<IndexOutOfRangeException>(() => product = this.productStock[2]);
        }
        [Test]
        public void RemoveMethodShouldRemoveSuccessfullyProduct()
        {
            this.productStock.Add(this.dummyProduct);
            this.productStock.Remove(this.dummyProduct);

            int expectedValue = 0;

            Assert.AreEqual(expectedValue, this.productStock.Count);
        }
        [Test]
        public void RemoveMethodShouldReorderCorrectly()
        {
            var products = new[]
            {
                new Product("Test1", 12, 12),
                new Product("Test2", 12, 12),
                new Product("FailProduct", 12, 12),
                new Product("Test3", 12, 12),
                new Product("Test4", 12, 12),
                new Product("Test5", 12, 12),
                new Product("Test6", 12, 12),
                new Product("Test7", 12, 12)
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }
            this.productStock.Remove(products[2]);

            for (int i = 2; i < this.productStock.Count; i++)
            {
                Assert.AreEqual(products[i + 1], this.productStock[i]);
            }
        }
        [Test]
        public void RemoveMethodShouldShrinkWhenTheArrayIsHalfEmpty()
        {
            var products = new[]
            {
                new Product("Test1", 12, 12),
                new Product("Test2", 12, 12),
                new Product("Test3", 12, 12),
                new Product("Test4", 12, 12),
                new Product("Test5", 12, 12)
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }
            this.productStock.Remove(productStock[3]);

            var expectedValue = 4;

            Assert.AreEqual(expectedValue, this.productStock.Capacity);
        }
        [Test]
        public void RemoveMethodSHouldReturnFalseWhenProductNotFound()
        {
            Assert.IsFalse(this.productStock.Remove(this.dummyProduct));
        }
        [Test]
        public void ContainsMethodShouldReturnTrue()
        {
            this.productStock.Add(dummyProduct);
            Product product = new Product("SSD", 13, 2);

            Assert.IsTrue(this.productStock.Contains(product));
        }
        [Test]
        public void ContainsMethodShouldReturnFalse()
        {
            this.productStock.Add(dummyProduct);
            Product product = new Product("HDD", 13, 2);

            Assert.IsFalse(this.productStock.Contains(product));
        }
        [Test]
        public void FindMethodShouldReturnTheRightProduct()
        {
            var products = new[]
            {
                new Product("Test1", 12, 12),
                new Product("Test2", 12, 12),
                new Product("Test3", 12, 12),
                new Product("Test4", 12, 12),
                new Product("Test5", 12, 12)
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }

            int index = 3;
            var expectedProduct = this.productStock[3];

            Assert.AreEqual(expectedProduct, this.productStock.Find(index));
        }
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(-1)]
        public void FindMethodShouldThrowIndexOutOfRangeException(int index)
        {
            this.productStock.Add(this.dummyProduct);
            Assert.Throws<IndexOutOfRangeException>(() => this.productStock.Find(index));
        }
        [Test]
        public void FindByLabelMethodShouldReturnTheCorrectProduct()
        {
            var products = new[]
            {
                new Product("Test1", 12, 12),
                new Product("Test2", 12, 12),
                new Product("Test3", 12, 12),
                new Product("Test4", 12, 12),
                new Product("Test5", 12, 12)
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }
            this.productStock.Add(this.dummyProduct);

            string labelToBeFound = "SSD";
            var expectedProduct = this.dummyProduct;

            Assert.AreEqual(expectedProduct, this.productStock.FindByLabel(labelToBeFound));
        }
        [Test]
        public void FindByLabelMethodShouldThrowArgumentExceptionForLabelNotFound()
        {
            var products = new[]
            {
                new Product("Test1", 12, 12),
                new Product("Test2", 12, 12),
                new Product("Test3", 12, 12),
                new Product("Test4", 12, 12),
                new Product("Test5", 12, 12)
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }

            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel("SSD"));
        }
    }
}
