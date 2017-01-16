using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotterShoppingCart.Tests;

namespace PotterShoppingCart
{
    public class PotterShoppingCart
    {
        public List<HarryPotter> Books { get; set; }

        public int GetPrice()
        {
            if (Books.Count == 2 && Books.Select(b => b.Seq).Distinct().Count() == 2)
            {
                return (int)Math.Round(Books.Sum(b => b.Price) * 0.95, 1, MidpointRounding.AwayFromZero);
            }

            return this.Books.Sum(b => b.Price);
        }
    }
}
