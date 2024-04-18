using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class Exercise01_StoreOrders
    {
       /*
       Sally's Pizza is bringing its pizza ordering system into the digital age
       to get better customer insights.

       They've encoded each of Sally's pizzas and other dishes as an integer:
	   * 10: small, cheese       20: medium, cheese       30: large, cheese
	   * 11: small, pepperoni    21: medium, pepperoni    31: large, pepperoni
	   * ---
	   * 40: calzone
	   * 41: spaghetti pie
	   * 42: baked ziti
       */

        // You can use these constants in your solutions.
        private const int SmallCheese = 10;
        private const int SmallPepperoni = 11;
                
        private const int MediumCheese = 20;
        private const int MediumPepperoni = 21;
                
        private const int LargeCheese = 30;
        private const int LargePepperoni = 31;
                
        private const int Calzone = 40;
        private const int SpaghettiPie = 41;
        private const int BakedZiti = 42;

        /*
        Each customer order, consisting of one or more items, is represented as an array
        where each value represents an item in that order.

        Create an "order" that contains the following items:
        * - small, cheese (SmallCheese)
        * - calzone (Calzone)
        * - large, pepperoni (LargePepperoni)
        * - spaghetti pie (SpaghettiPie)

        Examples:
        CreateOrder() → [10, 40, 31, 41]
        */

        public int[] CreateOrder()
        {
            return new int[] { };
        }

        /*
        Sally realized that she needed to know how many calzones her shop sells per day.

        Implement the logic to count the number of calzones sold per day when given an
        array representing each item that her customers ordered that day.

        Examples:
        GetCalzoneSales([Calzone, LargeCheese, LargePepperoni, Calzone, SmallCheese]) → 2
        which is the same as:
        GetCalzoneSales([40, 30, 31, 40, 10]) → 2
        GetCalzoneSales([LargeCheese, LargePepperoni, SmallCheese]) → 0
        GetCalzoneSales([]) → 0
        */
        public int GetCalzoneSales(int[] orders)
        {
            return 0;
        }

        /*
        Sally also needs to know the total revenue for all cheese pizzas sold on any given day.
            * Each small cheese pizza costs $8.
            * Each medium cheese pizza costs $11.
            * Each large cheese pizza costs $14.

        Implement the logic to return the total revenue of all cheese pizzas when given
        an array representing each item that her customers ordered that day.

        Examples:
        GetCheesePizzaRevenue([SmallCheese]) → 8
        GetCheesePizzaRevenue([SmallCheese, SmallPepperoni, MediumCheese]) → 19
        GetCheesePizzaRevenue([SmallPepperoni, MediumPepperoni]) → 0
        */
        public int GetCheesePizzaRevenue(int[] orders)
        {
            return 0;
        }
    }
}
