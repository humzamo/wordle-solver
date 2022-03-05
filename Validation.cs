using System.Linq;

namespace WordleSolver
{
    class Validation
    {
        private static char[] validLetterStates = new char[] { 'g', 'y', 'b' };

        public static string ValidateInputLength(string input)
        {
            while (input.Length != 5)
            {
                Console.WriteLine("Input must be five letters!");
                input = Console.ReadLine();
            }
            return input;
        }

        public static string ValidateLetterStates(string input)
        {
            input = ValidateInputLength(input);
            bool isValid = input.All(x => validLetterStates.Contains(x));

            while (!isValid)
            {
                input = ValidateInputLength(input);
                isValid = input.All(x => validLetterStates.Contains(x));
                if (!isValid)
                {
                    Console.WriteLine("Input must be be g, y, or b! Please try again");
                    input = Console.ReadLine();
                }
            }
            return input;
        }

        public static string ValidateWord(string word, string[] words)
        {
            bool validated = words.Contains(word);

            while (!validated)
            {
                word = ValidateInputLength(word);
                validated = words.Contains(word);
                if (!validated)
                {
                    Console.WriteLine("Invalid word entered! Please try again");
                    word = Console.ReadLine();
                }
            }
            return word;
        }
    }
}