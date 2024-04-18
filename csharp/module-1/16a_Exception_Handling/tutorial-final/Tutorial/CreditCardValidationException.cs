using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{

    // Step 2 - Create the CreditCardValidatiionException class

    class CreditCardValidationException : Exception
    {
        public CreditCardValidationException(string message) : base(message) { }
    }
}
