using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoopinCart
{
    public class PotterShoopinCart
    {
        public List<HarryPotter> Books { get; set; }

        public int PriceCalc()
        {
            var price = this.Books.Select(b => b.Price).Sum(p => p);


            if (Books.Count == 2 && Books.Select(b => b.Numero).Distinct().Count() == 2)
            {
                price = (int)Math.Round(price * 0.95, 0, MidpointRounding.AwayFromZero);
            }
            else if(Books.Count == 3 && Books.Select(b=>b.Numero).Distinct().Count() == 3)
            {
                price = (int)Math.Round(price * 0.9, 0, MidpointRounding.AwayFromZero);
            }

            return price;
        }
    }

    public class HarryPotter
    {
        public int Numero { get; set; }

        public int Price { get; } = 100;
    }
}