using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        Program prog = new Program();

        [Fact]
        public void TestQualityDecreasesBy1ByDefault()
        {
            var program = new Program();
            program.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            program.UpdateQuality();
            Assert.Equal(19, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityDecreasesBy2AndSellInDecreasesBy1WhenSellByDateHasBeenReached()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } }
            };
            program.UpdateQuality();
            Assert.Equal(-1, program.Items[0].SellIn);
            Assert.Equal(18, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityDecreasesBy2WhenSellByDateHasPassed()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 } }
            };
            program.UpdateQuality();
            Assert.Equal(18, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityDoesNotDecreaseWhenItIsZero()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 0 } }
            };
            program.UpdateQuality();
            Assert.Equal(0, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityIncreasesWhenItemIsAgedBrieAndItGetsOlder()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } }
            };
            program.UpdateQuality();
            Assert.True(program.Items[0].Quality > 0);
        }

        [Fact]
        public void TestQualityDoesNotIncreasePast50WhenItemIsAgedBrieAndItGetsOlder()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } }
            };
            program.UpdateQuality();
            Assert.Equal(50, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityAndSellInDoNotChangeWhenItemIsSulfuras()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 10 } }
            };
            program.UpdateQuality();
            Assert.Equal(5, program.Items[0].SellIn);
            Assert.Equal(10, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityIncreaseBy1WhenItemIsBackstagePassesAndItGetsOlderAndSellInIsGreaterThan10()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 } }
            };
            program.UpdateQuality();
            Assert.Equal(1, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityIncreasesBy2WhenItemIsBackstagePassesAndItGetsOlderAndSellInIs10()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 } }
            };
            program.UpdateQuality();
            Assert.Equal(2, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityIncreasesBy2WhenItemIsBackstagePassesAndItGetsOlderAndSellInIs6()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 0 } }
            };
            program.UpdateQuality();
            Assert.Equal(2, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityIncreasesBy3WhenItemIsBackstagePassesAndItGetsOlderAndSellInIs5()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 } }
            };
            program.UpdateQuality();
            Assert.Equal(3, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityIncreasesBy3WhenItemIsBackstagePassesAndItGetsOlderAndSellInIs1()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 0 } }
            };
            program.UpdateQuality();
            Assert.Equal(3, program.Items[0].Quality);
        }

        [Fact]
        public void TestQualityDropsToZeroWhenItemIsBackstagePassesAndItGetsOlderAndSellInIsZero()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } }
            };
            program.UpdateQuality();
            Assert.Equal(0, program.Items[0].Quality);
        }

        [Fact]
        public void TestConjuredItemsWithPositiveSellInDecreaseTwiceAsFast()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 6, Quality = 3 } }
            };
            program.UpdateQuality();
            Assert.Equal(1, program.Items[0].Quality);
        }
        [Fact]
        public void TestConjuredItemsWithOneSellInDecreaseByOne()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 3 } }
            };
            program.UpdateQuality();
            Assert.Equal(2, program.Items[0].Quality);
        }

        [Fact]
        public void TestConjuredItemsWithNegativeSellInDecreaseTwiceAsFast()
        {
            var program = new Program
            {
                Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 3 } }
            };
            program.UpdateQuality();
            Assert.Equal(-1, program.Items[0].Quality);
        }
    }

}
