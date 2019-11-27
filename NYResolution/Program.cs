using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NYResolution
{
    class Resolution
    {
        public static int Count = 0;
        public string description;
        public Resolution(string _description)
        {
            description = _description;
            Count++;
        }
    }
   /* New Years Resolutions(OOP approach)
1. Create an empty.txt file
2. Ask the user to add a New Years Resolution(at first, the user might add it in one line separated by a comma)
3. Write resolutions to the file
5. Create a new Class Resolution.The class has got only one property public string Description
4. Read the resolutions form the file and use the data that has been read from the file to create the instances(objects) of the Resolution class.
5. Add the objects to the list of New Years Resolutions
6. Display the items from the list of New Years Resolutions.
7. Let the user add a new resolution.Display the result.Write it to the file.
8. Let the user delete a resolution from the list.Display the result.Write it to the file.*/
    class Program
    {
        static void Main(string[] args)
        {
            List<Resolution> resolutionList = new List<Resolution>();
            Console.WriteLine("What are your New Year's resolution:");
            string userInput = Console.ReadLine();
            Resolution userResolution = new Resolution(userInput);
            resolutionList.Add(userResolution);

            AddToFile(resolutionList);
            Ask(resolutionList);
        }
        public static void Add(List<Resolution> resolutionList)
        {
            Console.WriteLine("Add a new resolution:");
            string userAnswer = Console.ReadLine();
            Resolution userResolution2 = new Resolution(userAnswer);
            resolutionList.Add(userResolution2);
        }
        public static void Remove(List<Resolution> removedToFile)
        {
            string filePath = @"/Users/Britta/Desktop/NewYearResolution/NewYearResolution.txt";
            File.ReadAllLines(filePath).ToList();
            List<string> removeToFile = new List<string>();
            Console.WriteLine("Remove your New Year Resolution:");
            string userInputRemove = Console.ReadLine();
            Resolution userResolution = new Resolution(userInputRemove);
            removedToFile.Remove(userResolution);
            File.WriteAllLines(filePath, removeToFile.ToArray());
            Console.WriteLine("Your resolution has been deleted");
        }
        public static void AddToFile(List<Resolution>resolutionList)
        {
            string filePath = @"/Users/Britta/Desktop/NewYearResolution/NewYearResolution.txt";
            List<string> inputToWriteToFile = new List<string>();
            Console.WriteLine("\nUpdated resolution list:");
            int j = 1;
            foreach (Resolution resolution in resolutionList)
            {
                inputToWriteToFile.Add(resolution.description);
                Console.WriteLine($"Resolution {j} on your New Year's resolution list is {resolution.description}");
                j++;
            }
            Console.WriteLine("Writing to a file...");
            File.WriteAllLines(filePath, inputToWriteToFile);
            Console.WriteLine("Your resolution has been added");
        }
        public static void Ask(List<Resolution> resolutionList)
        {
            Console.WriteLine("Would you like to add/remove your resolution or quit?");
            string userAnswer = Console.ReadLine();

            if (userAnswer.ToLower() == "add")
            {
                Add(resolutionList);
                AddToFile(resolutionList);
                Ask(resolutionList);
            }
            else if (userAnswer.ToLower() == "remove")
            {
                Remove(resolutionList);
            }
            else if(userAnswer.ToLower() == "quit")
            {
                Console.Clear();
                Console.WriteLine("Your New Year resolutions are:");
                int i = 1;
                foreach (Resolution resolution in resolutionList)
                {
                    Console.WriteLine($"Resolution {i} on your New Year Resolution list is {resolution.description}.");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Invalid entry!");
                Ask(resolutionList);
            }
        }
    }
}
