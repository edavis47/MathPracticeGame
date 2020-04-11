using System;
using System.Collections.Generic;
using System.Text;

namespace MathFlashCardsGame
{
    class GameFunctions
    {
        private static readonly Random rnd = new Random();
        public static int Addition(int i)
        {
            int a, b;
            GetRandomInts(out a, out b);
            int result = a + b;
            Console.Write($"{i}) {a} + {b} = ");
            return result;
        }
        public static int Subtraction(int i)
        {
            int a, b;
            GetRandomInts(out a, out b);
            int result = a - b;
            Console.Write($"{i}) {a} - {b} = ");
            return result;
        }
        public static int Multiplication(int i)
        {
            int a, b;
            GetRandomInts(out a, out b);
            int result = a * b;
            Console.Write($"{i}) {a} * {b} = ");
            return result;
        }
        public static double Division(int i)
        {
            double a = rnd.Next(-100, 101);
            double b = rnd.Next(-100, 101);
            a = Math.Round(a, 2);
            b = Math.Round(b, 2);
            double result = a / b;
            result = Math.Round(result, 2);
            Console.Write($"Round to the 100ths place :\n{i}) {a} / {b} = ");
            return result;
        }
        public static int Evaluate(double result, double answer)
        {
            if (answer == result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Great work, that's correct!");
                Console.ForegroundColor = ConsoleColor.White;
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Sorry, that is incorrect. The correct answer is : {result}");
                Console.ForegroundColor = ConsoleColor.White;
                return 0;
            }

        }
        private static void GetRandomInts(out int a, out int b)
        {
            a = rnd.Next(-100, 101);
            b = rnd.Next(-100, 101);
        }
    }
}