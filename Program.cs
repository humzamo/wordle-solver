using System.Linq;

namespace WordleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Models.wordList;

            while (words.Length > 1)
            {
                GiveSuggestions(words);

                Console.WriteLine("Please enter the input you tried for Wordle");

                string currentWord = Validation.ValidateWord(Console.ReadLine(), words);

                int distinctLetters = currentWord.Select(x => x.ToString()).Distinct().Count();

                Console.WriteLine("\nPlease enter the results from your input");

                string results = Validation.ValidateLetterStates(Console.ReadLine());
                var states = GenerateLetterStates(results);

                words = FilterWordsByState(words, currentWord, states);

                WordsLeft(words);
            }

            if (words.Length == 1)
            {
                Console.WriteLine("\nCongratulations! 🎉 The answer is: " + words[0]);
                System.Environment.Exit(1);
            }
            if (words.Length == 0)
            {
                Console.WriteLine("\nThere are no words left to try 😢");
                System.Environment.Exit(1);
            }

        }

        private static letterStates[] GenerateLetterStates(string input)
        {
            var inputArray = input.Select(x => x.ToString()).ToArray();
            letterStates[] output = new letterStates[5];

            for (int i = 0; i < 5; i++)
            {
                switch (inputArray[i])
                {
                    case "g":
                        output[i] = letterStates.Correct;
                        break;
                    case "y":
                        output[i] = letterStates.WrongLocation;
                        break;
                    case "b":
                        output[i] = letterStates.NotPresent;
                        break;
                }
            }
            Console.WriteLine("\nYour output letters were: ");
            foreach (letterStates state in output)
            {
                Console.Write(state.ToString() + " ");
            }
            Console.WriteLine("");
            return output;
        }

        private static string[] FilterWordsByState(string[] words, string currentWord, letterStates[] states)
        {
            for (int i = 0; i < 5; i++)
            {
                //TODO: How to handle one yellow and one black for same letter?
                if (states[i] == letterStates.Correct)
                {
                    words = words.Where(w => w[i] == currentWord[i]).ToArray();
                }

                if (states[i] == letterStates.NotPresent)
                {
                    words = words.Where(w => !w.Contains(currentWord[i])).ToArray();
                }

                if (states[i] == letterStates.WrongLocation)
                {
                    words = words.Where(w => w.Contains(currentWord[i])).ToArray();
                    words = words.Where(w => w[i] != currentWord[i]).ToArray();
                }
            }
            return words;
        }

        private static void GiveSuggestions(string[] words)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(1, words.Length);
            Console.WriteLine(string.Format("\nYou could try: {0}!\n", words[randomIndex]));
        }

        private static void WordsLeft(string[] words)
        {
            if (words.Length < 2) { return; }

            Console.WriteLine($"\nThere are {words.Length} words you can try. These are:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}