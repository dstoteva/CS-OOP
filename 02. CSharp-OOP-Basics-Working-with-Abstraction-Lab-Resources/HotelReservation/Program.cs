using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];

            Season newSeason = new Season();
            
            string discount = "no";

            if (input.Length == 4)
            {
                discount = input[3];
            }

            DiscountType newDiscount = new DiscountType();

            switch (season)
            {
                case "Autumn":
                    newSeason = Season.Autumn;
                    break;
                case "Summer":
                    newSeason = Season.Summer;
                    break;
                case "Winter":
                    newSeason = Season.Winter;
                    break;
                case "Spring":
                    newSeason = Season.Spring;
                    break;
            }
            switch (discount)
            {
                case "VIP":
                    newDiscount = DiscountType.VIP;
                    break;
                case "SecondVisit":
                    newDiscount = DiscountType.SecondVisit;
                    break;
                default:
                    newDiscount = DiscountType.no;
                    break;
            }
            var priceCalculator = new PriceCalculator(pricePerDay, numberOfDays, newSeason, newDiscount);
            Console.WriteLine($"{priceCalculator.CalculatePrice():f2}");
        }
    }
}
