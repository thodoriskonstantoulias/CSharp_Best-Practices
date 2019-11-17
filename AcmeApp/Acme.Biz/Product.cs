using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        //Constants initialized with value at the declaration and cannot change 
        //Readonly fields are initialized in the declaration or in the constructor and cannot get reassigned
        public const double InchesPerMeter = 39.97;
        public readonly decimal MinimalPrice;
        public Product()
        {
            Console.WriteLine("Product instance created");

            //We may not want to initialize the class each time because we need it in specific situations
            //Init here when we want it every time

            //this.ProductVendor = new Vendor();
            this.MinimalPrice = 9.6M;
        }
        public Product(int productId, string productName, string description) : this()
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            Console.WriteLine("Product instance with parameter created");
        }
       
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get 
            {
                //Lazy loading - instantiate when needed
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public string SaytheProductName()
        {
            //Associate classes - Instantiate here when only one method needs the class
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product class");
            return "The product name is : " + productName + " and the date is " + availabilityDate?.ToShortDateString();
        }



    }
}
