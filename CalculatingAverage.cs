using System;
using System.Linq;
using System.Collections.Generic;

namespace CalculatingAverages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumOfNumbers()); // Made sum a function so i could reuse it later. Should have created a less specific function but it was easy enough to do the first 3 problems with a call to get numbers and the hard coded 10.
            AverageTenScores(); //I should create an avg() function but since it's a simple enough equation i'll skip that for now. 
            AverageSpecificScores(); // I believe this is the answer you were looking for but i may have misunderstood the final outcome you were looking for.
            AverageNonSpecificScores();

        }

        private static void AverageNonSpecificScores()
        {
            Console.WriteLine("Enter test scores:(score, score, ...)");
            string input = Console.ReadLine();
            List<int> scoreList = new List<int> { };
            scoreList = input.Split(", ").Select(int.Parse).ToList();
            //Console.WriteLine(string.Join(", ", scoreList));
            double avg;
            avg = (1.0 * scoreList.Aggregate((a, b) => a + b)) / scoreList.Count();
            //Console.WriteLine(avg);
            GetGrade(avg);
        }

        private static void AverageSpecificScores()
        {
            Console.WriteLine("Enter number of tests");
            string input = Console.ReadLine();
            int numTests = int.Parse(input);
            for(int i = 0; i < numTests; i++)
            {
                Console.WriteLine($"Enter the scores for test {i + 1}");
                AverageTenScores();
            }
        }

        private static void AverageTenScores()
        {
            double avg = SumOfNumbers() / 10.0;
            //Console.WriteLine(avg);
            GetGrade(avg);
        }

        private static void GetGrade(double avg)
        {
            string grade;
            if (Math.Round(avg) >= 90)
            {
                grade = "A";
            }
            else if (Math.Round(avg) >= 80 && avg < 90)
            {
                grade = "B";
            }
            else if (Math.Round(avg) >= 70 && avg < 80)
            {
                grade = "C";
            }
            else if (Math.Round(avg) >= 60 && avg < 70)
            {
                grade = "D";
            }
            else
            {
                grade = "F";
            }
            Console.WriteLine($"The numerical average is {avg} and the letter grade is {grade}");
        }

        private static int SumOfNumbers()
        {
            int[] number = GetInput();
            int sum;
            sum = number.Aggregate((a, b) => a + b);
            //Console.WriteLine(string.Join(", ", number));
            //Console.WriteLine($"The sum of our inputs is {sum}"); 
            return sum;
        }

        private static int[] GetInput()
        {
            int[] number = new int[10];
            for (int i = 0; i < 10; i++)
            {
                string input;
                Console.WriteLine($"Input test score {i +1}");
                input = Console.ReadLine();
                number[i] = int.Parse(input);
                if (number[i] < 0 || number[i] > 100)
                {
                    Console.WriteLine("Input number between 0 and 100");
                    i--;
                }
            }

            return number;
        }
    }
}
