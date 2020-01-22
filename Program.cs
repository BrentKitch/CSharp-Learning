using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)   //Not using Math. functionality
        {
           
            string another;
            do {  //loops until user indicates they don't want to continue
          
            System.Console.Clear();  //erases the current screen. not useful the first time through but useful for multiple times through the same run 
            System.Console.WriteLine("Hello welcome to my basic calculator.");
            calculate(getNumber(), getNumber(), displayoplist()); //takes all of the inputed values and does the chosen operation 
            System.Console.WriteLine("Would you like to perform another operation? y/n "); 
            another = System.Console.ReadLine();
            }
            while (another != "n") ;

        }

        public static double Add(double a, double b) //Addition function
        {
            double c;
            c = a + b;
            return c;
        }
        public static double SUB(double a, double b)  // Subtraction function
        {
            double c;
            c = a - b;
            return c;
        }
        public static double MUL(double a, double b)  //Multiplication function
        {
            double c;
            c = a * b;
            return c;
        }
        public static double DIV(double a, double b) //Division function
        {
            double c;
            c = a / b;
            return c;
        }
        public static double POW(double a, double b) //To the power of function
        {
            double c = 1;
            for (int i = 0; i < b; i++) { 
                c = c * a;
            }
            return c;
        }
        public static void Display(double inputOne, double inputTwo, string op, double answer)   //Function to format the end result how i want it shown on the console
        {
            
            if (op == "F")
            {
                System.Console.WriteLine("You did not select a valid option");
            }
            else {
                if (inputTwo == 0 && op == "/")
                {
                    System.Console.WriteLine(($"The answer of {inputOne} {op} {inputTwo} is undefined"));
                }
                else
                {
                    System.Console.WriteLine(($"The answer of {inputOne} {op} {inputTwo} is {answer:F3}"));
                }                           
            }
        }
        public static int displayoplist() //operation selection function
        {
            System.Console.WriteLine("Please select the operation you would like to perform from the list below by typing the corresponding number");
            System.Console.WriteLine("1. Addition");
            System.Console.WriteLine("2. Subtraction");
            System.Console.WriteLine("3. Multiplication");
            System.Console.WriteLine("4. Division");
            System.Console.WriteLine("5. To the Power of");
            string opSel = System.Console.ReadLine();
            int opNum = int.Parse(opSel);
            return opNum;
        }
        public static double getNumber() //gets the users input for their number
        {
            System.Console.WriteLine("Enter Your number");
            string firstValR = System.Console.ReadLine();
            double firstVal = double.Parse(firstValR);
            return firstVal;
        }
        public static void calculate(double firstVal, double secondVal, int opNum) //calculates the inputed numbers and operation selection and displays it to the console
        {
            double answer = 0;
            string opVal;
            switch (opNum)  // switch case to run the funtion the user selected from the list , could make an array here to store and return both variable but in the spirit of keeping this very basic just going to stick with a switch case in the main
            {
                case 1:
                    answer = Add(firstVal, secondVal);
                    opVal = "+";
                    Display(firstVal, secondVal, opVal, answer); //displays the final result
                    break;
                case 2:
                    answer = SUB(firstVal, secondVal);
                    opVal = "-";
                    Display(firstVal, secondVal, opVal, answer); //displays the final result
                    break;
                case 3:
                    answer = MUL(firstVal, secondVal);
                    opVal = "x";
                    Display(firstVal, secondVal, opVal, answer); //displays the final result
                    break;
                case 4:
                    answer = DIV(firstVal, secondVal);
                    opVal = "/";
                    Display(firstVal, secondVal, opVal, answer); //displays the final result
                    break;
                case 5:
                    answer = POW(firstVal, secondVal);
                    opVal = "to the power of";
                    Display(firstVal, secondVal, opVal, answer); //displays the final result
                    break;
                default:
                    opVal = "F";
                    Display(firstVal, secondVal, opVal, answer); //displays the final result
                    break;
            }
        }
    }
}
