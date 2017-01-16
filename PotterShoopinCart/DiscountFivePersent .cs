using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoopinCart
{
    public class DiscountFivePersent : ICalculatePrice
    {
        public double DiscountValue
        {
            get
            {
                return 0.95;
            }
        }       

        Tuple<int, IEnumerable<int>> ICalculatePrice.CaculatePrice(IEnumerable<HarryPotter> Books, ref IEnumerable<int> caculated)
        {
            var price = 0;
            var _Caculated = caculated == null ? new List<int>() : caculated;
            var books = Books.Where(b => !_Caculated.Contains(b.GetHashCode()))
                        .GroupBy(b => b.Numero)
                        .Select(group => new { Numero = group.Key, Count = group.Count() });

            if (books.Count() != 2)
                return Tuple.Create(0, _Caculated);

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

            return Tuple.Create(price, _Caculated);
        }
    }
}
