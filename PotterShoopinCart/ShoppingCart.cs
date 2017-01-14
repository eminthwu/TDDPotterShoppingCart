using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoopinCart
{
    public class PotterShoopinCart
    {
        public List<HarryPotter> Books { get; set; }

        private List<int> _Counted { get; set; } = new List<int>();

        public int PriceCalc()
        {           
            var price = this.Books.Select(b => b.Price).Sum(p => p);
           
            if (Books.Count == 2 && Books.Select(b => b.Numero).Distinct().Count() == 2)
            {
                price = Discount_5Persent(price);
            }
            else if (Books.Count == 3 && Books.Select(b => b.Numero).Distinct().Count() == 3)
            {
                price = Discount_10Persent(price);
            }
            else if (Books.Count == 4 && Books.Select(b => b.Numero).Distinct().Count() == 4)
            {
                price = Discount_20Persent(price);
            }
            else if (Books.Count == 5 && Books.Select(b => b.Numero).Distinct().Count() == 5)
            {
                price = Discount_25Persent(price);
            }

            return price;
        }

        private static int Discount_25Persent(int price)
        {
            price = (int)Math.Round(price * 0.75, 0, MidpointRounding.AwayFromZero);
            return price;
        }

        private static int Discount_20Persent(int price)
        {
            price = (int)Math.Round(price * 0.8, 0, MidpointRounding.AwayFromZero);
            return price;
        }

        private static int Discount_10Persent(int price)
        {
            price = (int)Math.Round(price * 0.9, 0, MidpointRounding.AwayFromZero);
            return price;
        }

        private static int Discount_5Persent(int price)
        {
            price = (int)Math.Round(price * 0.95, 0, MidpointRounding.AwayFromZero);
            return price;
        }
    }

    public class HarryPotter
    {
        public int Numero { get; set; }

        public int Price { get; } = 100;
    }
}