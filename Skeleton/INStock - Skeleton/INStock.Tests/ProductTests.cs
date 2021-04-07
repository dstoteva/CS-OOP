namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
       // string Label { get; }
       //
       // decimal Price { get; }
       //
       // int Quantity { get; }
       [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string label = "SSD";
            decimal price = 1.2m;
            int quantity = 5;
            IProduct product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);

        }
        [Test]
        public void ConstructorInvalidLabelArgumentNullExcepton()
        {
            string invalidLabel = null;
            decimal price = 1.2m;
            int quantity = 5;

            Assert.Throws<ArgumentNullException>(() => new Product(invalidLabel, price, quantity));
        }
        [Test]
        public void ConstructorInvalidPriceArgumentExcepton()
        {
            string label = "HDD";
            decimal price = -1;
            int quantity = 5;

            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity));
        }
        [Test]
        public void ConstructorInvalidQuantityArgumentExcepton()
        {
            string label = "HDD";
            decimal price = 1.2m;
            int quantity = -1;

            Assert.Throws<ArgumentException>(() => new Product(label, price, quantity));
        }
        [Test]
        public void CompareToMethodShouldReturnLabelWithGreaterASCIISum()
        {
            var greaterProductLabel = "Zoom";
            var greaterProductPrice = 2.12m;
            var greaterProductQuantity = 3;

            var smallerProductLabel = "Do";
            var smallerProductPrice = 4.13m;
            var smallerProductQuantity = 2;

            var greaterProduct = new Product(greaterProductLabel, greaterProductPrice, greaterProductQuantity);
            var smallerProduct = new Product(smallerProductLabel, smallerProductPrice, smallerProductQuantity);

            var result = greaterProduct.CompareTo(smallerProduct);
            Assert.AreEqual(1, result);
        }
    }
}