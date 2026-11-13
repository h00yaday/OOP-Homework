using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
    public class Book : Product
    {
        public int PageCount { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }

        public Book(double price, string country, string name, DateTime packagingDate, string description, int pageCount, string authors, string publisher)
            : base(price, country, name, packagingDate, description)
        {
            PageCount = pageCount;
            Authors = authors;
            Publisher = publisher;
        }

        public override string GetDetails()
        {
            return $"{Description}, Pages: {PageCount}, Authors: {Authors}, Publisher: {Publisher}";
        }
    }
}
