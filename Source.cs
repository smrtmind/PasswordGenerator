namespace PasswordGenerator
{
    public class Source
    {
        public static string[] functions =
        {
            "Digits\t\t",
            "Small letters\t",
            "Capital letters\t",
            "Special symbols\t",
            "Exclude duplicates\t"
        };

        public static char[][] allSymbols =
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
    }
}
