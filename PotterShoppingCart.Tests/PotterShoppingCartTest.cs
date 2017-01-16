using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterShoppingCartTest
    {
        [TestMethod]
        public void GetPrice_第一集x1_100元()
        {
            //arrange
            PotterShoppingCart cart = new PotterShoppingCart()
            {
                Books = new List<HarryPotter>()
                {
                    new HarryPotter() { Seq = "1" }
                }
            };

            var excepted = 100;

            //act
            int actual = cart.GetPrice();

            //assert
            Assert.AreEqual(excepted, actual);

        }
    }
}
