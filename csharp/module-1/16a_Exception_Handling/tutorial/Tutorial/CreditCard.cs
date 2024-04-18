using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial
{
    public class CreditCard
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Number { get; set; }
        public string SecurityCode { get; set; }

        public virtual void Validate()
        {
            // Step 4: Validate cardholder name


            // Step 5: Validate card number


            // Step 6: Validate security code


        }

        public override string ToString()
        {
            return $"Name: '{FirstName} {LastName}', Number: {Number}, Security Code: {SecurityCode}";
        }

        private bool IsDigits(string str)
        {
            foreach (char ch in str.ToCharArray())
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
