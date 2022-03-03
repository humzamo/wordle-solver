namespace WordleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Models.wordList;

            while (true)
            {
                GiveSuggestions(words);

                Console.WriteLine("Please enter the input you tried for Wordle\n");

                string currentWord = Console.ReadLine();
                if (currentWord.Length != 5)
                {
                    Console.WriteLine("Input must be five letters!");
                    System.Environment.Exit(1);
                }
                Console.WriteLine($"Your current word is {currentWord}\n");

                Console.WriteLine("Please enter the results from your input");
                string results = Console.ReadLine();
                var states = GenerateLetterStates(results);

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

                if (words.Length == 1)
                {
                    Console.WriteLine("\nCongratulations! The answer is: " + words[0]);
                    System.Environment.Exit(1);
                }

                Console.WriteLine($"There are {words.Length} words you can try. These are:");
                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
            }
        }

        private static letterStates[] GenerateLetterStates(string input)
        {
            Console.WriteLine("You entered: " + input);
            if (input.Length != 5)
            {
                Console.WriteLine("Input must be five letters!");
                System.Environment.Exit(1);
            }

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
                    default:
                        Console.WriteLine("Input must be be g, y, or b!");
                        System.Environment.Exit(1);
                        return null;
                }
            }
            Console.Write("Your output letters were: ");
            foreach (letterStates state in output)
            {
                Console.Write(state.ToString() + " ");
            }
            Console.Write("");
            return output;
        }

        void GiveSuggestions(string[] words)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(1, words.Length);
            Console.WriteLine(string.Format("You could try: {0}!\n", words[randomIndex]));
        }
    }
}