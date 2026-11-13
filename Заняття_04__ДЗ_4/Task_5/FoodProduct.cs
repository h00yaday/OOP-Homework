using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
    public class FoodProduct : Product
    {
        public int ShelfLife { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public FoodProduct(double price, string country, string name, DateTime packagingDate, string description, int shelfLife, double quantity, string unit)
            : base(price, country, name, packagingDate, description)
        {
            ShelfLife = shelfLife;
            Quantity = quantity;
            Unit = unit;
        }
        public override string GetDetails()
        {
            return $"{Description}, {Quantity} {Unit}, shelf life: {ShelfLife} days";
        }
    }
}
