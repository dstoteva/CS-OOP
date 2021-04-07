using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HotelReservation
{
    public class PriceCalculator
    {
        private decimal pricePerDay;
        private int numberOfDays;
        private Season season;
        private DiscountType discount;

        public PriceCalculator(decimal pricePerDay, int numberOfDays, Season season, DiscountType discount)
        {
            PricePerDay = pricePerDay;
            NumberOfDays = numberOfDays;
            Season = season;
            Discount = discount;
        }
        public decimal CalculatePrice()
        {
            int multiplier = (int)this.season;
            decimal discountMultiplier = (decimal)this.discount / 100;

            decimal price = this.pricePerDay * this.numberOfDays * multiplier;
            decimal finalPrice = price - (price * discountMultiplier);

            return finalPrice;
        }
        public decimal PricePerDay { get => pricePerDay; set => pricePerDay = value; }
        public int NumberOfDays { get => numberOfDays; set => numberOfDays = value; }
        public Season Season { get => season; set => season = value; }
        public DiscountType Discount { get => discount; set => discount = value; }
    }
}
