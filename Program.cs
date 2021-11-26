using System;
using System.Collections.Generic;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            bool[] options = new bool[5];

            int choice = default;

            Console.WriteLine("Choose password length");
            int.TryParse(Console.ReadLine(), out int passwordLength);


            while (input != "<")
            {
                Console.Clear();

                Console.WriteLine("[1] Digits\n" +
                                  "[2] Little letters\n" +
                                  "[3] Big letters\n" +
                                  "[4] Special Symbols\n" +
                                  "[5] Avoid duplicates\n");

                Console.WriteLine("What do you want to use in the password?");
                input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                    options[choice - 1] = true;

                int counterOfOptions = default;
                for (int i = 0; i < options.Length; i++)
                    if (options[i]) counterOfOptions++;

                if (counterOfOptions == 5) break;
            }
        }
    }
}
