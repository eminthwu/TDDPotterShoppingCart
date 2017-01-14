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
           

            return price;
        }
    }

    public class HarryPotter
    {
        public int Numero { get; set; }

        public int Price { get; } = 100;
    }
}