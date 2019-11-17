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
    }
}
