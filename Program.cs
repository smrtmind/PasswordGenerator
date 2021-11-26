using System;
using System.Collections.Generic;

namespace PasswordGenerator
{
    class Program
    {
        public static char[][] overallArray = 
        {
            new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' },

            new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                         'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },

            new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                         'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'},

            new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=',
                         '+', '?', '<', '>', ':', ';', '.', ',', '|', '/', '~', '{', '}',
                         '[', ']', '№', '\'', '\"','\\'}
        };

        static void Main(string[] args)
        {
            string input = string.Empty;
            bool[] options = new bool[5];
            Random random = new Random();

            int choice = default;

            Console.WriteLine("Choose password length");
            int.TryParse(Console.ReadLine(), out int passwordLength);


            while (input != ">")
            {
                Console.Clear();

                Console.WriteLine("[1] Digits\n" +
                                  "[2] Little letters\n" +
                                  "[3] Big letters\n" +
                                  "[4] Special Symbols\n" +
                                  "[5] Avoid duplicates\n\n" +
                                  "[>] Generate password\n");

                Console.WriteLine("What do you want to use in the password?");
                input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                    options[choice - 1] = true;

                int counterOfOptions = default;
                for (int i = 0; i < options.Length; i++)
                    if (options[i]) counterOfOptions++;

                if (counterOfOptions == 5) break;
            }

            List<char> test = new List<char>();
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i])
                {
                    for (int j = 0; j < overallArray[i].Length; j++)
                    {
                        test.Add(overallArray[i][j]);
                    }
                }
            }

            char[] password = new char[passwordLength];
            for (int i = 0; i < password.Length; i++)
                password[i] = test[random.Next(0, test.Count)];

            Console.WriteLine($"\n\nYour password is: {new string(password)}");
        }
    }
}
