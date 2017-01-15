using System;
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

            //price += Discount_25Persent();
            price += Discount_20Persent();
            price += Discount_10Persent();
            price += Discount_5Persent();
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
                new DiscountTwentyFivePercent()
            };

            return output;
        }

        private int Discount_25Persent()
        {
            var price = 0;
            var books = Books.Where(b => !_Caculated.Contains(b.GetHashCode()))
                        .GroupBy(b => b.Numero)
                        .Select(group => new { Numero = group.Key, Count = group.Count() });

            if (books.Count() != 5)
                return 0;

            var sets = books.Select(b => b.Count).Max();
            var numeros = books.Select(b => b.Numero).Distinct();

            foreach (var numero in numeros)
            {
                var caculatedBooks = Books.Where(b => b.Numero == numero).Take(sets);
                if (caculatedBooks.Count() < sets)
                    continue;
                price += caculatedBooks.Sum(b => (int)Math.Round(b.Price * 0.75, 0, MidpointRounding.AwayFromZero));
                _Caculated = _Caculated.Concat(caculatedBooks.Select(b => b.GetHashCode()));
            }

            return price;
        }

        private int Discount_20Persent()
        {
            var price = 0;
            var books = Books.Where(b => !_Caculated.Contains(b.GetHashCode()))
                        .GroupBy(b => b.Numero)
                        .Select(group => new { Numero = group.Key, Count = group.Count() });

            if (books.Count() != 4)
                return 0;

            var sets = books.Select(b => b.Count).Max();
            var numeros = books.Select(b => b.Numero).Distinct();

            foreach (var numero in numeros)
            {
                var caculatedBooks = Books.Where(b => b.Numero == numero).Take(sets);
                if (caculatedBooks.Count() < sets)
                    continue;
                price += caculatedBooks.Sum(b => (int)Math.Round(b.Price * 0.8, 0, MidpointRounding.AwayFromZero));
                _Caculated = _Caculated.Concat(caculatedBooks.Select(b => b.GetHashCode()));
            }

            return price;
        }

        private int Discount_10Persent()
        {
            var price = 0;
            var books = Books.Where(b => !_Caculated.Contains(b.GetHashCode()))
                        .GroupBy(b => b.Numero)
                        .Select(group => new { Numero = group.Key, Count = group.Count() });

            if (books.Count() != 3)
                return 0;

            var sets = books.Select(b => b.Count).Max();
            var numeros = books.Select(b => b.Numero).Distinct();

            foreach (var numero in numeros)
            {
                var caculatedBooks = Books.Where(b => b.Numero == numero).Take(sets);
                if (caculatedBooks.Count() < sets)
                    continue;
                price += caculatedBooks.Sum(b => (int)Math.Round(b.Price * 0.9, 0, MidpointRounding.AwayFromZero));
                _Caculated = _Caculated = this._Caculated.Concat(caculatedBooks.Select(b => b.GetHashCode()));
            }

            return price;
        }

        private int Discount_5Persent()
        {
            var price = 0;
            var books = Books.Where(b => !_Caculated.Contains(b.GetHashCode()))
                        .GroupBy(b => b.Numero)
                        .Select(group => new { Numero = group.Key, Count = group.Count() });

            if (books.Count() != 2)
                return 0;

            var sets = books.Select(b => b.Count).Max();
            var numeros = books.Select(b => b.Numero).Distinct();

            foreach (var numero in numeros)
            {
                var caculatedBooks = Books.Where(b => b.Numero == numero).Take(sets);
                if (caculatedBooks.Count() < sets)
                    continue;
                price += caculatedBooks.Sum(b => (int)Math.Round(b.Price * 0.95, 0, MidpointRounding.AwayFromZero));
                _Caculated = _Caculated.Concat(caculatedBooks.Select(b => b.GetHashCode()));
            }

            return price;
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