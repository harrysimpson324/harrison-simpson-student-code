using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    // Step 7: Create the MasterCard class
    class MasterCard : CreditCard
    {
        public override void Validate()
        {
            base.Validate();

            // MasterCard numbers always begin with '5'.
            if (Number[0] != '5')
            {
                throw new CreditCardValidationException($"'{Number}' - Invalid MasterCard card number, must begin with '5'.");
            }
        }
    }
}
