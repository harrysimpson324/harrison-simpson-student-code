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
            if (string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(FirstName))
            {
                throw new CreditCardValidationException($"'{FirstName} {LastName}' - Cardholder name is invalid, must provide first and last names.");
            }

            // Step 5: Validate card number
            if (string.IsNullOrEmpty(Number) || ((Number.Length != 13) && (Number.Length != 16)) || (!IsDigits(Number)))
            {
                throw new CreditCardValidationException($"'{Number}' - Card number is too short or too long, or not all digits.");
            }

            // Step 6: Validate security code
            if (string.IsNullOrEmpty(SecurityCode) || (SecurityCode.Length != 3) || (!IsDigits(SecurityCode)))
            {
                throw new CreditCardValidationException($"'{SecurityCode}' - Security code is too short or too long, or not all digits.");
            }
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
