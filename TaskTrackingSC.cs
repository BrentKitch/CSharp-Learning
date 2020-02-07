using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskTracking
{
    class TaskTrackingSC
    {
        public static List<string> tasks = new List<string> {};
        public static int taskNumber = -1;
        public static List<int> completedTasks = new List<int> {};
        public static int pageNumber;
        static void Main(string[] args) //needs option to start with a previous list from a text file or new inputed list. 
        {
            WelcomeDisplay();
        }

        private static void WelcomeDisplay()
        {
            Console.WriteLine("Super Awesome Simple Task Tracker");
            Console.WriteLine("Would you like to upload tasks from a .txt file? y/n");
            if(Console.ReadLine() == "y")
            {
                ImportFile();
            }
            Console.WriteLine("Press any key to start tracker and view list of tasks");
            string pause = Console.ReadLine();
            GraphicDisplay();
        }

        private static void ImportFile()
        {
            tasks = System.IO.File.ReadAllLines(@"D:\Embry-Riddle\Visual Studio Projects\TaskTracking\Tasks.txt").ToList();  //Change this file path to where your task list (.txt) is saved
        }
        private static void SaveFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Embry-Riddle\Visual Studio Projects\TaskTracking\Tasks.txt")) //Change this file path to where you want to save your list of tasks
            {
                for(int i = 0; i < tasks.Count; i++)
                {
                    if (completedTasks.Contains(i))
                    {

                    }
                    else
                    {
                        file.WriteLine(tasks[i]);
                    }
                    
                }
            }
            taskNumber--;
        }
        private static void ReTask()
        {
            completedTasks.Add(taskNumber);
            tasks.Add(tasks[taskNumber]);
           
        }

        private static void FinTask()
        {
            completedTasks.Add(taskNumber);
            completedTasks.Sort();
           
        }

        private static void AddTask()
        {
            Console.Clear();
            Console.WriteLine("What task would you like to add to the list?");
            tasks.Add(Console.ReadLine());
            taskNumber--;
        }


        private static void GraphicDisplay()
        {
            //full console display which updates after every input. 

            do
            {
                taskNumber++;
                pageNumber = taskNumber / 20;
                Console.Clear();

                for (int i =(20 * pageNumber); i < (20 * (pageNumber + 1)); i++)
                {
                    if (i == tasks.Count)
                    {
                        break;
                    }
                    if (i == taskNumber && completedTasks.Contains(i))
                    {
                        CrossOut(i);
                        taskNumber++;
                    }
                    else if (i == taskNumber)
                    {
                        Highlight(i);
                    }
                    else if (completedTasks.Contains(i))
                    {
                        CrossOut(i);
                    }
                    else
                    {
                        Console.WriteLine(tasks[i]);
                    }
                }
                OptionDisplay();
    
            } while ( ListCheck() || taskChoice(Console.ReadLine()) != "n"  ); 
        }

        private static bool ListCheck()
        {
            bool listWrap = false; 
            if (taskNumber == tasks.Count) //list wrap
            {
                taskNumber = -1;
                listWrap = true;
                for (int i = 0; i < completedTasks.Count; i++)       //cleanup topside of list
                {
                    if (completedTasks.Contains(i))
                    {
                        tasks.RemoveAt(i);
                        completedTasks.Remove(i);
                        for(int a = 0; a < completedTasks.Count; a++)
                        {
                            completedTasks[a] = completedTasks[a] - 1;
                        }
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
                if(tasks.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You have completed all of your Tasks.");
                    Console.WriteLine("Would you like to (a: Add a task) to the list?");
                    taskChoice(Console.ReadLine());
                    taskNumber++;
                }
            }

            return listWrap;
        }

        private static string taskChoice(string choice)
        {
            switch (choice)
            {
                case "c":
                    FinTask();
                    break;
                case "r":
                    ReTask();
                    break;
                case "a":
                    AddTask();
                    break;
                case "e":
                    ActionTask();
                    break;
                case "n":      //if the user wants to break out of the loop but this option is never prompted.
                    return "n";
                case "i":
                    SaveFile();
                    break;
                default:
                    break;
            }
            return "y";  //you can check out any time you like but you can never leave, because it will never return n to break the loop.
        }

        private static void ActionTask()
        {
            Console.Clear();
            Console.WriteLine($"You are working on {tasks[taskNumber]}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("---------------------------------");
            Console.Write("c: Complete Task | ");
            Console.Write("r: Re-Enter Task\n");
            taskChoice(Console.ReadLine());
        }

        private static void OptionDisplay()
        {
            Console.WriteLine($"Page: {pageNumber + 1}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("---------------------------------");
            Console.Write("e: Enter Task | ");
            Console.Write("s: Skip Task | ");
            Console.Write("a: Add Task | ");
            Console.Write("i: Save Tasks\n");

        }

        private static void Highlight(int i)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(tasks[i]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void CrossOut(int i)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(tasks[i]);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
