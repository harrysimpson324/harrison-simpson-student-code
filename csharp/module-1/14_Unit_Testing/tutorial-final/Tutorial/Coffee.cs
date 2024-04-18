using System;
using System.Collections.Generic;
using System.Text;

namespace TechElevator.Bookstore
{
    public class Coffee : IPurchasable
    {
        public Coffee(string size, string blend, string[] additions, decimal price)
        {
            Size = size;
            Blend = blend;
            this.additions = new List<string>(additions);
            Price = price;
        }

        public string Size { get; set; }
        public string Blend { get; set; }

        private List<string> additions = new List<string>();
        public string[] Additions
        {
            get
            {
                return this.additions.ToArray();
            }
        }
        public decimal Price { get; set; }

        public bool IsTaxable
        {
            get
            {
                return false;
            }
        }

        public void Add(string addition)
        {
            additions.Add(addition);
        }

        public override string ToString()
        {
            return $"Coffee: {Size} {Blend} ({string.Join(", ", additions)}). Price: {Price:C}";
        }
    }
}
