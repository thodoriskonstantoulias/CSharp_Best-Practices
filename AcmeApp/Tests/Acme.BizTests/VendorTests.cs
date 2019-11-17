using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }
        //Uncomment if you want the bool return 
        //[TestMethod()]
        //public void PlaceOrderTest()
        //{
        //    var vendor = new Vendor();
        //    var product = new Product(1, "Saw,", "");
        //    var expected = true;
        //    var actual = vendor.PlaceOrder(product, 3);

        //    Assert.AreEqual(expected, actual);
        //}
        //[TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void PlaceOrderNullProduct()
        //{
        //    var vendor = new Vendor();
        //    var actual = vendor.PlaceOrder(null, 3);
        //}
        [TestMethod()]
        public void PlaceOrderTest()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw,", "");
            var expected = new OperationResult(true, "Order from Acme Inc.\r\nProduct : Tools-1\r\nQuantity : 3");
            var actual = vendor.PlaceOrder(product, 3);

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderNullProduct()
        {
            var vendor = new Vendor();
            var actual = vendor.PlaceOrder(null, 3);
        }

        //We name the arguments for clarity or define enums for better understanding
        [TestMethod()]
        public void PlaceOrderTest_WithAddress()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw,", "");
            var expected = new OperationResult(true, "Test With Address");
            var actual = vendor.PlaceOrder(product, 3, Vendor.IncludeAddress.Yes, Vendor.SendCopy.No);

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
    }
}