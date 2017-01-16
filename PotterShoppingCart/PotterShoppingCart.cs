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
        /// 已經計價過的書本清單
        /// </summary>
        private IEnumerable<int> _CalculatedBooks { get; set; } = new List<int>();

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
                    { 5, 0.75 },
                    { 4, 0.8 },
                    { 3, 0.9 },
                    { 2, 0.95 },
                    { 1, 1 }
                };
            }
        }

        public int GetPrice()
        {
            var price = 0;

            foreach (var discount in _DiscountRatio)
            {
                price += GetDiscountPrice(discount.Key);
            }

            return price;
        }

        private int GetDiscountPrice(int particularSets)
        {
            var partitionBooks = from b in Books
                                 where !_CalculatedBooks.Contains(b.GetHashCode())
                                 group b by b.Seq into temp
                                 select new
                                 {
                                     Seq = temp.Key,
                                     Count = temp.Count()
                                 };
            
            //尚未計算價錢的書中，以集數為分組條件，計算總共有幾套
            var booksCount = partitionBooks.Count();

            //如果算出來的適用優惠種類與指定的優惠種類不符，則不適用指定的優惠折扣
            if (booksCount != particularSets)
                return 0;

            var disCountPrice = 0;
            IEnumerable<int> calculatedBooks = new List<int>();
            //找出適用的目前指定優惠的套數 
            var avaliableSets = partitionBooks.Select(p => p.Count).Min();

            foreach (var partition in partitionBooks)
            {                     
                //依照目前書本集數挑出以及套數適用優惠的書
                var books = Books.Where(b => b.Seq == partition.Seq).Take(avaliableSets);
                var booksPrice = books.Sum(b => b.Price);
                disCountPrice += booksPrice;

                //已經計算過優惠的書不得再計算優惠，將其記入已計算的清單
                calculatedBooks = calculatedBooks.Concat(books.Select(b => b.GetHashCode()));
            }

            _CalculatedBooks = _CalculatedBooks.Concat(calculatedBooks);
            disCountPrice = (int)Math.Round(disCountPrice * _DiscountRatio[particularSets], 0, MidpointRounding.AwayFromZero);
            return disCountPrice;
        }
    }
}
