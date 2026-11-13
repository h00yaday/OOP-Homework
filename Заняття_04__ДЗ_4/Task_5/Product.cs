using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
    public class Product
    {
        public double Price { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public DateTime PackagingDate { get; set; }
        public string Description { get; set; }

        public string Details
        {
            get
            {
                return GetDetails();
            }
        }

        public Product(double price, string country, string name, DateTime packagingDate, string description)
        {
            Price = price;
            Country = country;
            Name = name;
            PackagingDate = packagingDate;
            Description = description;
        }
        public virtual string GetDetails()
        {
            return Description;
        }
    }
}
