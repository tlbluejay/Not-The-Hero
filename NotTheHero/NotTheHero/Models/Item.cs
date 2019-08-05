using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.Models
{
    class Item
    {
        //enum ItemQuality
        //{
        //    JUNK,
        //    UNCOMMON,
        //    COMMON,
        //    RARE,
        //    EPIC,
        //    LEGENDARY,
        //    EXOTIC,
        //    DEVITEM
        //}

        public string Name { get; set; }
        public int PriceValue { get; set; }
        public string FlavorText { get; set; }
        public bool Trashable { get; set; }
        //public ItemQuality Rarity { get; set; }
    }
}
