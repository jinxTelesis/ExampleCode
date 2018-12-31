using System;
using Hwk_1Library; // this is DLL I created




//c:\users\dremo\source\repos\Hwk-1Library\Class1  - DLL location for my own covience 

namespace Hwk_1CountryConsoleAndreL
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            CountryAppUnitTesting unitTestObj = new CountryAppUnitTesting();// couldn't call first time, forgot to do final build

            while (true) // main loop
            {
                selection = userSelection(); // calls a function selection loop, could just have one have a little less cluttered main like this
                if (selection == 1)
                {
                    unitTestObj.UnitTestCurrency(); // calls unit test on currency // user is prompted in the userSelction function
                }

                if (selection == 2)
                {
                    unitTestObj.UnitTestCurrency(); // calls unit test on currency
                }

                if (selection == 3) // can't actually get here would have exited on other loop
                {
                    Environment.Exit(-1);
                }
            }
        }

        static void printMenu() // just a menu to display options
        {
            Console.WriteLine("Country Testing Menu");
            Console.WriteLine("--------------------");
            Console.WriteLine("1 - Unit Test Currency");
            Console.WriteLine("2 - Unit Test Language");
            Console.WriteLine("3 - Exit");
            Console.WriteLine("Enter Choice :");
        }

        static int userSelection() // returns value to main, little bit redundant 
        {

            int selection = -1;
            while (true)
            {
                printMenu();
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine()); // reads user input
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid choice please enter 1, 2 or 3");
                }

                if (selection == 1)
                {
                    return 1;
                }

                if (selection == 2)
                {
                    return 2;
                }

                if (selection == 3)
                {
                    Environment.Exit(-1); // exit code
                }

            }
        }
    }
}
