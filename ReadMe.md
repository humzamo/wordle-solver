# Dotnet Wordle Solver

##### A Dotnet console application for ~~cheating~~ helping you solve Wordle puzzles 😉

#### Instructions

1. Launch the application by using the `dotnet run` command in the main directory.
2. The application will give you an initial suggestion for a word to try. You can ignore this if you want!
3. Type the word you entered into Wordle.
   - Make sure to type five letters or the application will give you an error and exit!
4. Type the output given by Wordle.
   - This will be "b" for a black square, "g" for a green square, and "y" for a yellow square.
   - E.g. for output 🟨 🟨 🟩 ⬛ 🟩, enter "yygbg" in the console.
   - Make sure to type five letters or the application will give you an error and exit!
5. At each iteration, the application will reduce the number of words based on the Wordle rules until you have the answer!

#### Bugs to Fix

- How to handle one yellow and one black for same letter?
  e.g. OTTOS => bybbb for day 190 (12/26/21)

#### To Do

[ ] Simplify the word list initialisation (maybe by parsing a list of words?)
