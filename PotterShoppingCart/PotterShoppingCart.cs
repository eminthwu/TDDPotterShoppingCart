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
            var distinctSeq = Books.Select(b => b.Seq).Distinct().Count();

            if (Books.Count == 2 && distinctSeq == 2)
            {
                return GetDiscountPrice(0.95);
            }
            else if (Books.Count == 3 && distinctSeq == 3)
            {
                return GetDiscountPrice(0.9);
            }

            return this.Books.Sum(b => b.Price);
        }

        private int GetDiscountPrice(double discountRatio)
        {
            return (int)Math.Round(Books.Sum(b => b.Price) * discountRatio, 1, MidpointRounding.AwayFromZero);
        }
    }
}
