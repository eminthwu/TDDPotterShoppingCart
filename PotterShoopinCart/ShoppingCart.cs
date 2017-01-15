using System.Collections.Generic;
using System.Linq;

namespace PotterShoopinCart
{
    public class PotterShoopinCart
    {
        public List<HarryPotter> Books { get; set; }

        private IEnumerable<int> _Caculated { get; set; } = new List<int>();

        public int PriceCalc()
        {
            IEnumerable<ICaculatePrice> discounts = GetDiscounts();

            var price = 0;

            foreach (var discount in discounts)
            {
                IEnumerable<int> caculated = _Caculated;
                var result = discount.CaculatePrice(Books, ref caculated);
                price += result.Item1;
                _Caculated = _Caculated.Concat(result.Item2).Distinct();
            }
                        
            price += Discount_None();

            return price;
        }

        /// <summary>
        /// 目前有在使用的折扣種類並依照優先順序回傳,順位高的在前
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ICaculatePrice> GetDiscounts()
        {
            var output = new List<ICaculatePrice>()
            {
                new DiscountTwentyFivePercent(),
                new DiscountTwentyPercent(),
                new DiscountTenPersent(),
                new DiscountFivePersent()
            };

            return output;
        }

        private int Discount_None()
        {
            var price = Books.Where(b => !_Caculated.Contains(b.GetHashCode())).Sum(b => b.Price);
            return price;
        }
    }

    public class HarryPotter
    {
        public int Numero { get; set; }

        public int Price { get; } = 100;
    }
}