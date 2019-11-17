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
            this.Category = "Tools";
        }
        public Product(int productId, string productName, string description) : this()
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            Console.WriteLine("Product instance with parameter created");
        }
        public decimal Cost { get; set; }
        //To make getters and setters meaningfull add code to transform the input
        private string productName;

        public string ProductName
        {
            get 
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set 
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product name must be at least 3 characters";
                }
                else if (value.Length > 20) 
                {
                    ValidationMessage = "Product name must not be more than 20 characters";
                }
                else
                {
                    productName = value;
                }              
            }
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
        public string Category { get; set; }
        //We can set the value in the property 
        public int SequenceNumber { get; set; } = 1;
        //Expression-bodied properties for ProductCode
        //public string ProductCode => this.Category + "-" + this.SequenceNumber;
        //And we can format it like below 
        public string ProductCode => $"{this.Category}-{this.SequenceNumber}";

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public string ValidationMessage { get; private set; }

        public string SaytheProductName()
        {
            //Associate classes - Instantiate here when only one method needs the class
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product class");
            return "The product name is : " + productName + " and the date is " + availabilityDate?.ToShortDateString();
        }

        //Example for method overriding below
        public override string ToString()
        {
            return this.productName + " (" + this.productId + ")";
        }

        //Example of expression-bodied methods - c# 6.0
        public decimal CalculateSuggestedPrice(decimal percent) => this.Cost + (this.Cost * percent / 100);

    }
}
