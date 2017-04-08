using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }
            };



            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQuality(Items[i]);
            }
        }

        public void UpdateQuality(Item item)
        {

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            if (item.Name == "Aged Brie")
            {
                item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0)
                {
                    item.Quality = item.Quality + 2;
                }
                else
                {
                    item.Quality = item.Quality + 1;
                }

                item.Quality = item.Quality > 50 ? 50 : item.Quality;
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {

                item.SellIn = item.SellIn - 1;

                if (item.SellIn < 5)
                {
                    item.Quality = item.Quality + 3;
                }
                else if (item.SellIn < 10)
                {
                    item.Quality = item.Quality + 2;
                }
                else
                {
                    item.Quality = item.Quality + 1;
                }

                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }

                item.Quality = item.Quality > 50 ? 50 : item.Quality;

            }
            else if (item.Name == "Conjured Mana Cake")
            {

                item.SellIn = item.SellIn - 1;

                
                 if (item.SellIn < 0)
                {
                    item.Quality = item.Quality - 4;
                }
               else if (item.SellIn >= 0)
                {
                    item.Quality = item.Quality - 2;
                }


            }
            else if (item.Quality > 0)
            {
                item.SellIn = item.SellIn - 1;

                if (item.Quality > 0 && item.SellIn < 0)
                {
                    item.Quality = item.Quality - 2;
                }
                else
                {
                    item.Quality = item.Quality - 1;
                }
            }

        }

    }

    public class Item
    {
        public const string AgedBrie = "Aged Brie";
        public const string TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string DexterityVest = "+5 Dexterity Vest";
        public const string ElixirMongoose = "Elixir of the Mongoose";
        public const string ManaCake = "Conjured Mana Cake";

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public object Clone()
        {
            return new Item() { Name = this.Name, Quality = this.Quality, SellIn = this.SellIn };
        }
    }

}
