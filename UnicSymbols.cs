using System.Collections.Generic;

namespace PasswordGenerator
{
    class UnicSymbols
    {
        public static char[] Get(char[] password, List<char> accumulatedArray)
        {
            while (true)
            {
                for (int i = 0; i < password.Length; i++)
                    password[i] = accumulatedArray[Program.random.Next(0, accumulatedArray.Count)];

                bool[] unicSymbols = new bool[password.Length];

                for (int i = 0; i < password.Length; i++)
                {
                    for (int j = 0; j < password.Length; j++)
                    {
                        if (password[i] == password[j] && i != j)
                        {
                            unicSymbols[i] = false;
                            break;
                        }

                        else unicSymbols[i] = true;
                    }
                }

                int unicCounter = default;
                for (int i = 0; i < unicSymbols.Length; i++)
                    if (unicSymbols[i]) unicCounter++;

                if (unicCounter == unicSymbols.Length)
                    break;
            }

            return password;
        }
    }
}
