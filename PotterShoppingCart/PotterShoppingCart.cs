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

        /// <summary>
        /// 優惠套數與折扣數定義在此，折扣順位高的要定義在前
        /// key: sets; value: discount ratio
        /// </summary>
        private Dictionary<int, double> _DiscountRatio
        {
            get
            {
                return new Dictionary<int, double>()
                {
                    { 1, 1 },
                    { 2, 0.95 },
                    { 3, 0.9 },
                    { 4, 0.8 },
                    { 5, 0.75 }
                };
            }
        }

        public int GetPrice()
        {
            var distinctSeq = Books.Select(b => b.Seq).Distinct().Count();

            return GetDiscountPrice(distinctSeq);
        }

        private int GetDiscountPrice(int particularSets)
        {
            return (int)Math.Round(Books.Sum(b => b.Price) * _DiscountRatio[particularSets], 0, MidpointRounding.AwayFromZero);
        }
    }
}
