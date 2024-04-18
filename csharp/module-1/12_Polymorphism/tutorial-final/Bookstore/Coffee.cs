using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class Coffee : IPurchasable
    {
        public string Size { get; set; }
        public string Blend { get; set; }
        public List<string> Additions { get; private set; } = new List<string>();
        public decimal Price { get; set; }

        public void Add(string addition)
        {
            Additions.Add(addition);
        }

        public override string ToString()
        {
            return $"{Size} coffee, {Blend} ({string.Join(", ", Additions)}). Price: ${Price}";
        }

        public Coffee(string size, string blend, string[] additions, decimal price)
        {
            Size = size;
            Blend = blend;
            Additions.AddRange(additions);
            Price = price;
        }
    }
}
