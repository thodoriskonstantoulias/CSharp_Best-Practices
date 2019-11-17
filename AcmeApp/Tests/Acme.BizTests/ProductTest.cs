using System;
using Acme.Biz;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.BizTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void SaytheProductNameTest()
        {
            var product = new Product(1, "mobile phone","descr for mobile");
            var expected = "The product name is : mobile phone and the date is ";
            var actual = product.SaytheProductName();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductNameFormat()
        {
            var product = new Product();
            var expected = "Product name test";
            product.ProductName = " Product name test ";
            var actual = product.ProductName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CategoryDefaultValue()
        {
            var product = new Product();
            var expected = "Tools";
            var actual = product.Category;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductCodeTestValue()
        {
            var product = new Product();
            var expected = "Tools-1";
            var actual = product.ProductCode;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ToStringTest()
        {
            var product = new Product(1,"Saw",null);
            var expected = "Saw (1)";
            var actual = product.ToString();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateSuggestedPriceTest()
        {
            var product = new Product(1, "Saw", null);
            product.Cost = 50M;
            var expected = 55m;
            var actual = product.CalculateSuggestedPrice(10M);
            Assert.AreEqual(expected, actual);
        }
    }
}
