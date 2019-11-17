using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        //We will use the enums for clarity as method arguments
        public enum IncludeAddress { Yes, No };
        public enum SendCopy { Yes, No };
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }
        //How methods should be written, below

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the product to order</param>
        /// <returns></returns>
        
        //Typical method returns bool 
        //If we want our method to return multiple fields we return OperationResult class which has more than one fields

        //public bool PlaceOrder(Product product, int quantity)
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            //Defencive coding first
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            //Body of method
            var success = false;
            var orderText = "Order from Acme Inc." + System.Environment.NewLine +
                            "Product : " + product.ProductCode + System.Environment.NewLine +
                            "Quantity : " + quantity;
            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);
            if (confirmation.StartsWith("Message sent: "))
            {
                success = true;
            }
            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the product to orde</param>
        /// <param name="includeAdress">True to include shipping address</param>
        /// <param name="sendCopy">True to send copy</param>
        /// <returns>Success flag and order text</returns>
        public OperationResult PlaceOrder(Product product, int quantity, IncludeAddress includeAddress, SendCopy sendCopy)
        {
            var orderTest = "Test";
            if (includeAddress == IncludeAddress.Yes) orderTest += " With Address";
            if (sendCopy == SendCopy.Yes) orderTest += " With Copy";
            var operationResult = new OperationResult(true,orderTest);
            return operationResult;
        }

        //The following is to practice with string methods
        public override string ToString()
        {
            //string vendorInfo = "Vendor : " + this.CompanyName;

            //Test nullable types
            string vendorInfo = null;
            string result;
            if (!string.IsNullOrWhiteSpace(vendorInfo))
            {
                result = vendorInfo.ToLower();
                result = vendorInfo.ToUpper();
            }
            

            return vendorInfo;
        }

    }
}
