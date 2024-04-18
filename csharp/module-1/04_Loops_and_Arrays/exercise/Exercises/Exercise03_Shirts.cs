using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises
{
    public class Exercise03_Shirts
    {
        private const char SmallShirt = 'S';
        private const char MediumShirt = 'M';
        private const char LargeShirt = 'L';

        /*
        A t-shirt company rep from Top Threads just finished taking an order
        from a client and needs to key it into the system. The client ordered,
        3 Small shirts ('S'), 2 Medium shirts ('M'), and 1 Large shirt ('L').

        Implement the logic to reflect an order of 6 t-shirts.

        Examples:
        BuildOrder() → ['S', 'S', 'S', 'M', 'M', 'L']
        */
        public char[] BuildOrder()
        {
            return new char[] { };
        }

        /*
        Another customer called in and is hosting a large networking event and
        needs a bulk order. Rather than indicate how many of each shirt they
        wanted, they've asked for as even distribution as possible.

        Implement the logic to generate an order representing as even a distribution
        as possible, for example: ('S', 'M', 'L', 'S', 'M', 'L', 'S', ...)

        Note: The number of shirts ordered is guaranteed to be non-negative.

        Examples:
        BuildBulkOrder(6) → ['S', 'M', 'L', 'S', 'M', 'L']    
        BuildBulkOrder(3) → ['S', 'M', 'L']
        BuildBulkOrder(4) → ['S', 'M', 'L', 'S']
        BuildBulkOrder(0) → []
        */
        public char[] BuildBulkOrder(int numberOfShirts)
        {
            return new char[] { };
        }

        /*
        The warehouse is out of small shirts and will only request more when the
        next order comes in that includes an 'S' shirt.

        Implement the logic to look through the next incoming order `char[] order`
        and return true if we need to place an order for Small shirts.

        Examples:
        PlaceRequest(['M', 'L', 'S']) → true
        PlaceRequest(['M', 'S', 'L']) → true
        PlaceRequest(['M', 'M', 'L']) → false
        PlaceRequest([]) → false
        */
        public bool PlaceRequest(char[] order)
        {
            return false;
        }
    }
}
