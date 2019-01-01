using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hwk2Library_Andre_lussier;

//***********************************************
// File: Program.cs
//
// Main Driver program
// Purpose:  control loop with 8 options
//          1: Reads JSON file, 2: Reads XML file 
//          3: Writes JSON file, 4 : Writes XML file
//          5: Displays contents of countryList of List<Country> type
//          Which contains Lists of Currency and Language classes
//          6: Displays contents of a specified country
//          7: Displays all the contries found by a specific currency code 
//          they contain
//          8: exits the program.
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*************************************************



namespace CountryConsole3AndreLussier
{
    class Program
    {
        static void Main(string[] args)
        {

            #region variables for main
            List<Country> countryList = new List<Country>();
            int userChoice = -1;
            string currentFile = "";
            string coutryName = "";
            int searchPostion = -1;
            string codeName = "";
            #endregion


            #region region for the control loop
            while (true)
            {
                userChoice = UserSelection();

                switch (userChoice)
                {
                    // Case 1: Calls the  deserializer with the users filename and puts the data into countryList 

                    case 1: // Read JSON FILE
                        Console.WriteLine("Enter a JSON filename to read Country list");
                        currentFile = Console.ReadLine();
                        DeserJSON desrJ = new DeserJSON();
                        countryList = desrJ.serDataAndReturn(currentFile, countryList);
                        break;

                    // Case 2: Calls the XML 

                    case 2: // READ XML FILE
                        Console.WriteLine("Enter a XML filename to read Country list from");
                        currentFile = Console.ReadLine();
                        DeserXML desrXML = new DeserXML();
                        countryList = desrXML.SerDataAndReturn(currentFile, countryList);
                        break;

                    // Case 3: writes file to user selected filename with existing country data in JSON

                    case 3: // WRITE JSON
                        Console.WriteLine("Enter a JSON filename to write Country list to");
                        currentFile = Console.ReadLine();
                        if(countryList.Count == 0)
                        {
                            Console.WriteLine("No data but writing anyways!");
                        }
                        SerJson serJson = new SerJson(currentFile, countryList);
                        Console.WriteLine("File succefully written");
                        break;

                    // Case 4: wriltes file to user select filename with existing country data in XML

                    case 4: // WRITE XML
                        Console.WriteLine("Enter a XML filename to write Country list to");
                        currentFile = Console.ReadLine();
                        if (countryList.Count == 0)
                        {
                            Console.WriteLine("No data but writing anyways!");
                        }
                        SerXML serXML = new SerXML(currentFile, countryList);
                        Console.WriteLine("File succefully written");
                        break;

                  

                    /// <summary>
                    /// Case 5: foreach loop that displays all the data by calling To_String
                    /// which calls other To_Strings in the respective classes
                    /// </summary>


                    case 5: // Display ALL Country List items on screen
                        Console.WriteLine("Displaying entire country list");
                        if(countryList.Count != 0)
                        {
                            foreach(Country x in countryList)
                            {
                                Console.WriteLine(x.ToString());
                            }
                        }
                        break;

                    /// <summary>
                    /// Case 6: checks if data is empty before trying to find element
                    /// lambda in the findIndex just pulls out country name when it equals
                    /// the entered country name countryList[i].Name.Equals(coutryName);
                    /// inside a for loop would also work
                    /// </summary>

                    case 6: // find and display country by name

                        Console.WriteLine("Enter country name please");
                        coutryName = Console.ReadLine();
                        Country tempCountry = new Country();
                        
                        if (countryList.Count != 0)
                        {
                            // lambda that accesses items in coutryList 
                            searchPostion = countryList.FindIndex(countryElem => countryElem.Name.Equals(coutryName)); 

                            tempCountry = countryList[searchPostion];
                            Console.WriteLine(searchPostion);
                            Console.WriteLine(tempCountry.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Error no data!");
                        }

                        break;

                    /// <summary>
                    /// case 7: nested loop that uses the size of the country list
                    /// than the length of currencies in the sub country to print 
                    /// out the country that it is inside
                    /// </summary>


                    case 7: // find and display countries that use a given currency code //C:\Users\dre\Desktop\countries_for_hwk\countries_for_hwk.json
                        Console.WriteLine("Enter currency code name please");
                        codeName = Console.ReadLine();

                        if (countryList.Count !=0)
                        {
                            for (int i = 0; i < countryList.Count;i++) // can't nest the lambdas they don't accept each others return for find all
                            {

                                for(int j = 0; j < countryList[i].Currencies.Count; j++)
                                {

                                    try // ghetto jagged array inner will run into nulls rarely produced by equals not ToString()
                                    {
                                        if (countryList[i].Currencies[j].Code.Equals(codeName))
                                        {
                                            Console.WriteLine(countryList[i].Name);
                                        }
                                    }catch(NullReferenceException)
                                    {
                                        // do nothing just index 1 too far
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error no data!");
                        }

                        break;

                    case 8: // not possible but makes it line up nice

                        break; // it will exit in the other loop always


                }

                #endregion end for control loop
            }
        }

        #region functions for main program

        /// <summary>
        /// Method: PrintMenu
        /// 
        /// Purpose: menu for the selection loops
        /// </summary>

        static void PrintMenu()
        {
            Console.WriteLine("Country Menu");
            Console.WriteLine("------------");
            Console.WriteLine("1 - Read List of Country from JSON file");
            Console.WriteLine("2 - Read List of Country from XML file");
            Console.WriteLine("3 - Write List of Country to JSON file");
            Console.WriteLine("4 - Write List of Country to XML file");
            Console.WriteLine("5 - Display All Country List Items on Screen");
            Console.WriteLine("6 - Find and display country by name");
            Console.WriteLine("7 - Find and display countires that use a given currency code");
            Console.WriteLine("8 - Exit");
            Console.WriteLine("Enter Choice");


        }

        /// <summary>
        /// Method: UserSelection
        /// 
        /// Purpose: reads user input in try catch the foor loop is just 
        ///          breaks out if the value is in the valid range 
        /// </summary>
        /// <returns> int for the user selection, value match the menu</returns>

        static int UserSelection()
        {
            int selection = -1;
            while (true)
            {
                PrintMenu();
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid choice! type 8 to exit");
                }

                if (selection == 8)
                {
                    Environment.Exit(-1);
                }

                for (int i = 0; i < 8; i++) // code just breaks out of this loop for all values 
                {
                    if (selection == i)
                    {
                        return i;
                    }
                }

            }

        }

        #endregion end of functions for main program
    }
}
