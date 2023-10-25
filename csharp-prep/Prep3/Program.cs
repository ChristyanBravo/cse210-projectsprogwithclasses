using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101); 
        int guess;
        int attempts = 0;
        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine("Welcome to Guess My Number Game!");
            Console.WriteLine("I have selected a magic number between 1 and 100.");
            Console.WriteLine("Can you guess it?");

            do
            {
                Console.Write("Enter your guess: ");
                guess = Convert.ToInt32(Console.ReadLine());
                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {attempts} attempts!");
                }
            } while (guess != magicNumber);

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();

            if (playAgainInput != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thank you for playing. Goodbye!");
            }
            else
            {
                magicNumber = random.Next(1, 101); 
                attempts = 0; 
            }
        }
    }
}
