using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN
{
    class Program
    {
        static void Main(string[] args)
        {
            string output;

            try
            {
                switch (args[0].ToLower())
                {
                    case "/validate":
                    case "/v":
                        Isbn isbn = new Isbn(args[1]);
                        output = String.Format("ISBN {0} is {1}", isbn.ToString(), isbn.isValid() ? "valid" : "invalid");
                        break;
                    case "/generate":
                    case "/g":
                        output = Isbn.Generate().ToString();
                        break;
                    default:
                        throw new ArgumentException("Invalid Argument");
                }
            }
            catch (Exception ex)
            {
                output = String.Format("Error: {0}", ex.Message);
            }

            Console.WriteLine(output);
                
        }
    }
}
