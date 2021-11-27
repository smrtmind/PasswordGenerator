using System;

namespace PasswordGenerator
{
    public class Print
    {
        public static void Text(string text, ConsoleColor color = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void Options(bool[] options)
        {
            Text(" Symbols\n\n", ConsoleColor.DarkBlue);

            for (int i = 0; i < options.Length; i++)
            {
                if (options[i])
                {
                    Text($" [{i + 1}] ", ConsoleColor.DarkBlue);
                    Text($"{Source.functions[i]} ", ConsoleColor.DarkGray);
                    Text($"+\n", ConsoleColor.DarkBlue);
                }

                else 
                    Text($" [{i + 1}] {Source.functions[i]}\n"); 
            }

            Text("\n [>] Generate password\n\n");
        }
    }
}
