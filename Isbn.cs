using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN
{
    class Isbn
    {
        public short[] Numbers { get; private set; }

        public Isbn(string isbnString)
        {
            string isbnNumbers = isbnString.Replace("-", "").Trim();
            Numbers = new short[isbnNumbers.Length];
            
            for (int i = 0; i < isbnNumbers.Length; i++)
            {
                if (isbnNumbers[i] == 'X' || isbnNumbers[i] == 'x')
                    Numbers[i] = 10;
                else
                    Numbers[i] = (short)Char.GetNumericValue(isbnNumbers[i]);
            }
        }

        public bool isValid()
        {
            if (Numbers.Length != 10)
                return false;
            int sum = 0;
            for (int i = 0; i < Numbers.Length / 2; i++)
                sum += (i + 1) * (Numbers[Numbers.Length - i - 1] - Numbers[i]);
            return sum % 11 == 0;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Numbers.Length; i++)
            {
                builder.Append(Numbers[i] == 10 ? "X" : Numbers[i].ToString());
                if (i == 0 || i == 4 || i == 8)
                    builder.Append("-");
            }
            return builder.ToString();
        }

        public static Isbn Generate()
        {
            StringBuilder builder = new StringBuilder();
            Random rand = new Random();
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int number = rand.Next(10);
                sum += number*(10-i);
                builder.Append(number);
            }
            builder.Append(sum%11 == 1 ? "X" : (11-(sum%11)).ToString());
            return new Isbn(builder.ToString());
        }


        //TODO: LOOKUP http://xisbn.worldcat.org/webservices/xid/isbn/0596002815?method=getMetadata&format=xml&fl=*
    }
}
