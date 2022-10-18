using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tecalliance.Carpool.Models
{
    public class UserInputCheck
    {
        //Get user input and Checks if its only string
        public string CheckStringInput(string frage)
        {
            string input;
            do
            {
                Console.WriteLine(frage);
                input = Console.ReadLine();
            } while (input.Any(c => !char.IsLetter(c))||input == "");
            return input;
        }
        //Get user input and Checks if its only Int
        public int CheckIntInput(string frage)
        {
            string input;
            do
            {
                Console.WriteLine(frage);
                input =Console.ReadLine();
            } while (input.Any(c => !char.IsNumber(c)) || input != " " || input=="");
            return Convert.ToInt32(input);
        }
        //Get user input and Checks if its only String and int for Login
        public string CheckLoginInput(string frage)
        {
            string input;
            do
            {
                Console.WriteLine(frage);
                input = Console.ReadLine();
            } while (input == "");
            return input;
        }
        //Get user input and Checks if its only in Datetime format
        public DateTime CheckDateTimeInput(string frage)
        {
            string input;
            do
            {
                Console.WriteLine(frage);
                input = Console.ReadLine();
            } while (!Regex.IsMatch(input, "^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$") || input == "");
            return Convert.ToDateTime(input);
        }

    }
}
