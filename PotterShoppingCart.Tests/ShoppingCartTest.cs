using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoopinCart;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void PriceCalc_第一集x1_100元()
        {
            //arrange
            var target = new PotterShoopinCart.PotterShoopinCart()
            {
                Books = new List<HarryPotter>()
                {
                    {new HarryPotter() {Numero = 1 } }
                }
            };

            var expected = 100;

            //act
            int actual = target.PriceCalc();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PriceCalc_第一集x1_第二集x1_190元()
        {
            //arrange
            var target = new PotterShoopinCart.PotterShoopinCart()
            {
                Books = new List<HarryPotter>()
                {
                    {new HarryPotter() { Numero = 1 } },
                    {new HarryPotter() { Numero = 2 } }
                }
            };

            var expected = 190;

            //act
            int actual = target.PriceCalc();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PriceCalc_第一到三集各一本_270元()
        {
            //arrange
            var target = new PotterShoopinCart.PotterShoopinCart()
            {
                Books = new List<HarryPotter>()
                {
                    {new HarryPotter() {Numero = 1 } },
                    {new HarryPotter() {Numero = 2 } },
                    {new HarryPotter() {Numero = 3 } },
                }
            };

            var expected = 270;

            //act
            int actual = target.PriceCalc();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PriceCalc_第一到四集各一本_320元()
        {
            //arrange
            var target = new PotterShoopinCart.PotterShoopinCart()
            {
                Books = new List<HarryPotter>()
                {
                    {new HarryPotter() {Numero = 1 } },
                    {new HarryPotter() {Numero = 2 } },
                    {new HarryPotter() {Numero = 3 } },
                    {new HarryPotter() {Numero = 4 } },
                }
            };

            var expected = 320;

            //act
            int actual = target.PriceCalc();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PriceCalc_第一集到五集各一本_375元()
        {
            //arrange
            var target = new PotterShoopinCart.PotterShoopinCart()
            {
                Books = new List<HarryPotter>()
                {
                    {new HarryPotter() {Numero = 1 } },
                    {new HarryPotter() {Numero = 2 } },
                    {new HarryPotter() {Numero = 3 } },
                    {new HarryPotter() {Numero = 4 } },
                    {new HarryPotter() {Numero = 5 } },
                }
            };

            var expected = 375;

            //act
            int actual = target.PriceCalc();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PriceCalc_第一集x1_第二集x1_第三集x2_370元()
        {
            //arrange
            var target = new PotterShoopinCart.PotterShoopinCart()
            {
                Books = new List<HarryPotter>()
                {
                    {new HarryPotter() {Numero = 1 } },
                    {new HarryPotter() {Numero = 1 } },
                    {new HarryPotter() {Numero = 3 } },
                    {new HarryPotter() {Numero = 3 } },
                }
            };

            var expected = 370;

            //act
            int actual = target.PriceCalc();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] 
        public void PriceCalc_第一集x1_第二集x2_第三集x2_460元()
        {
            //arrange
            var target = new PotterShoopinCart.PotterShoopinCart()
            {
                Books = new List<HarryPotter>()
                {
                    {new HarryPotter() {Numero = 1 } },
                    {new HarryPotter() {Numero = 2 } },
                    {new HarryPotter() {Numero = 2 } },
                    {new HarryPotter() {Numero = 3 } },
                    {new HarryPotter() {Numero = 3 } },
                }
            };

            var expected = 460;

            //act
            int actual = target.PriceCalc();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}