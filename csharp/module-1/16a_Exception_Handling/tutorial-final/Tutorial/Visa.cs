using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    // Step 8: Create the Visa class
    public class Visa : CreditCard
    {
        public override void Validate()
        {
            base.Validate();

            // Visa numbers always begin with '4'.
            if (Number[0] != '4')
            {
                throw new CreditCardValidationException($"'{Number}' - Invalid Visa card number, must begin with '4'.");
            }
        }
    }
}
