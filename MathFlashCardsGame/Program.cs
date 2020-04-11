using System;
using System.Text;

namespace MathFlashCardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Run();
        }
        private static void Run()
        {
            int numCorrect = 0;
            double result;
            double answer;
            int numProbs = 0;
            double total = 0;
            try
            {
                Console.WriteLine($"Welcome to Math Practice!\n\n{MainMenu()}");
                switch (Console.ReadLine())
                {
                    case "1": // Additon
                        numProbs = NumOfProbsPrompt();
                        Console.WriteLine($"Here is {numProbs} addition problems!");
                        for (int i = 1; i <= numProbs; i++)
                        {
                            result = GameFunctions.Addition(i);
                            answer = GetUserAnswer(ref numCorrect, result);
                        }
                        total = CalcScore(numCorrect, numProbs);
                        break;
                    case "2": // Subtraction
                        numProbs = NumOfProbsPrompt();
                        Console.WriteLine($"Here is {numProbs} subtraction problems!");
                        for (int i = 1; i <= numProbs; i++)
                        {
                            result = GameFunctions.Subtraction(i);
                            answer = GetUserAnswer(ref numCorrect, result);
                        }
                        total = CalcScore(numCorrect, numProbs);
                        break;
                    case "3": // Multiplication
                        numProbs = NumOfProbsPrompt();
                        Console.WriteLine($"Here is {numProbs} multiplication problems!");
                        for (int i = 1; i <= numProbs; i++)
                        {
                            result = GameFunctions.Multiplication(i);
                            answer = GetUserAnswer(ref numCorrect, result);
                        }
                        total = CalcScore(numCorrect, numProbs);
                        break;
                    case "4": // Divison (100ths place)
                        Console.WriteLine($"Here is {numProbs} Divison (roundeed to the 100ths place) problems!");
                        numProbs = NumOfProbsPrompt();
                        for (int i = 1; i <= numProbs; i++)
                        {
                            result = GameFunctions.Division(i);
                            answer = GetUserAnswer(ref numCorrect, result);
                        }
                        total = CalcScore(numCorrect, numProbs);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                Console.ReadLine();
                Console.Clear();
                Run();
            }
        }
        // Retrieves user's answer and updates the score accordingly
        private static double GetUserAnswer(ref int score, double result)
        {
            double answer;
            Console.ForegroundColor = ConsoleColor.Green;
            double.TryParse(Console.ReadLine(), out answer);
            Console.ForegroundColor = ConsoleColor.White;
            answer = Math.Round(answer, 2);
            score += GameFunctions.Evaluate(result, answer);
            return answer;
        }
        // Prompts user to enter number of problems they want and returns as int
        private static int NumOfProbsPrompt()
        {
            int numProbs;
            Console.WriteLine("How many problems would you like to perform?");
            int.TryParse(Console.ReadLine(), out numProbs);
            return numProbs;
        }
        // Calculates the score and prints it to screen
        private static double CalcScore(int score, int numProbs)
        {
            double total = ((Convert.ToDouble(score) / Convert.ToDouble(numProbs)) * 100);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nYou scored {score} out of {numProbs} correct, your score is {Math.Round(total, 2)}");
            Console.ForegroundColor = ConsoleColor.White;
            return total;
        }
        //this returns the menu in string format
        private static string MainMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.Append("Enter a number to choose questions of the corresponding function type:\n");
            menu.Append(" 1 - Addition\n");
            menu.Append(" 2 - Subtraction\n");
            menu.Append(" 3 - Multiplication\n");
            menu.Append(" 4 - Division (to the 100ths place)\n");
            menu.Append(" 0 - Leave Game\n");
            menu.Append("\nChoose your type : ");
            return menu.ToString();
        }
    }
}