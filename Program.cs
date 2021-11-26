using System;
using System.Collections.Generic;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int choice = default;

            Console.WriteLine("Choose password length");
            int.TryParse(Console.ReadLine(), out int passwordLength);


            while (choice == 0 || choice > 5)
            {
                Console.WriteLine("What do you want to use in the password?");
                string input = Console.ReadLine();
                int.TryParse(input, out choice);

                numbers.Add(choice);

                if (input == "<") break;
            }
        }
    }
}
