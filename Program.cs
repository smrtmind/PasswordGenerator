using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PasswordGenerator
{
    class Program
    {
        public static char[] password;
        public static List<char> accumulatedArray;
        public static Random random = new Random();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string input = string.Empty;

            while (input != "y")
            {
                int passwordLength = default;
                bool[] options = new bool[Source.functions.Length];

                do
                {
                    Console.Clear();
                    Print.Text(" Password generator\n\n", ConsoleColor.DarkMagenta);
                    Print.Text(" Enter password length (1 - 100): ");

                    int.TryParse(Console.ReadLine(), out passwordLength);
                    password = new char[passwordLength];
                }
                while (password.Length < 1 || password.Length > 100);

                while (true)
                {
                    while (true)
                    {
                        //choosing functions
                        input = string.Empty;
                        while (input != ">")
                        {
                            Console.Clear();
                            Print.Text(" Password generator\n\n", ConsoleColor.DarkMagenta);
                            Print.Text($" Enter password length (1 - 100): {passwordLength}\n\n");
                            Print.Options(options);

                            Print.Text(" Input: ", ConsoleColor.DarkBlue);
                            input = Console.ReadLine();

                            //allow to mark functions as "use" or "don't use"
                            if (int.TryParse(input, out int choice) && choice > 0 && choice <= Source.functions.Length)
                            {
                                if (!options[choice - 1])
                                    options[choice - 1] = true;
                                else
                                    options[choice - 1] = false;
                            }
                        }

                        //checking if at least one function was selected
                        int falseCounter = default;
                        for (int i = 0; i < options.Length; i++)
                            if (!options[i]) falseCounter++;

                        if (falseCounter == options.Length)
                        {
                            Print.Text(" No function selected", ConsoleColor.DarkRed);
                            Thread.Sleep(2000);
                        }

                        else break;
                    }

                    accumulatedArray = new List<char>();
                    //accumulating an array according to chosen options
                    for (int i = 0; i < options.Length - 1; i++)
                    {
                        if (options[i])
                        {
                            for (int j = 0; j < Source.allSymbols[i].Length; j++)
                                accumulatedArray.Add(Source.allSymbols[i][j]);
                        }
                    }

                    //if you want to exclude duplicates from password
                    if (options[options.Length - 1])
                    {
                        //if length of password larger than chosen accumulated array of symbols
                        if (password.Length > accumulatedArray.Count)
                        {
                            Print.Text(" Can't create password without duplicates\n" +
                                       " Password length is greater than amount of unic symbols\n", ConsoleColor.DarkRed);
                            Thread.Sleep(4000);
                        }

                        else
                        {
                            password = GetUnicSymbols();
                            break;
                        }
                    }

                    //if you don't mind about duplicates
                    else
                    {
                        for (int i = 0; i < password.Length; i++)
                            password[i] = accumulatedArray[random.Next(0, accumulatedArray.Count)];
                        break;
                    }
                }

                Print.Text($"\n Output: ", ConsoleColor.DarkBlue);
                Print.Text($"{new string(password)}\n");
                Print.Text($" file with password was created on your desktop\n\n", ConsoleColor.DarkGray);
                File.WriteAllText(@"C:\Users\[name_of_the_user]\Desktop\password.txt", new string(password));

                do
                {
                    Print.Text(" Exit the program? [y] / [n]: ");
                    input = Console.ReadLine().ToLower();
                }
                while (input != "y" && input != "n");
            }
        }

        private static char[] GetUnicSymbols()
        {
            for (int i = 0; i < password.Length; i++)
            {
                int index = random.Next(0, accumulatedArray.Count);

                password[i] = accumulatedArray[index];
                accumulatedArray.Remove(accumulatedArray[index]);
            }

            return password;
        }
    }
}
