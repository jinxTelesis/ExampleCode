using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hwk2Library_Andre_lussier;
using System.Runtime.Serialization.Json; // dll for Json moved to secondary class 
using System.IO;
using DresSearlizer;
using DresDesearlizer;
using MyXMLSerNamespace;
using MyXMLDeSerNamespace;


//*****************************************
// File : Program.cs
//
// Purpose: This is the driver program 
// the cu, lang, country ref/pointers need their types existing for the 
// seralizters to make a runtime gettype determination
// the program has a print menu method and a UserSelction method
// the UserSelection returns a value to the main control while loop
// which runs the correct seralization/deserialization with the specified type
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*****************************************

namespace CountryConsoleAppAndreLussier_hw2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region variables for main
            int selection = 0;
            String command = "";
            String DEFAULTCURFILE ="cur";
            String DEFAULTLANGFILE = "lang";
            String DEFAULTCOUNTRYFILE ="country";
            String JSON = ".json";
            String XML = ".XML";


            Currency cu = new Currency();

            Language lang = new Language();

            Country country = new Country();

            #endregion end of variables for main

            //********************************
            // line 50ish to 365 are the control statments for the menu
            // the the tests for default value or user entered specific file 
            // 5, 10, 15 are display menus that access toString of the class objects
            // the type is passed in a run time
            // ***********************************************************************

            #region main while loop

            while (true)
            {
                selection = UserSelection();
                if(selection == 1)
                {
                    Console.WriteLine("Enter path of a JSON file or type default");
                    command = Console.ReadLine();
                    if(command.Equals("default"))
                    {
                        JsonDseralizer jds = new JsonDseralizer(); 
                        jds.setdeserilizer(DEFAULTCURFILE + JSON, cu);
                    }
                    else
                    {
                        JsonDseralizer jds = new JsonDseralizer(); 

                        try {
                            jds.setdeserilizer(command, cu);
                        } catch(IOException e)
                        {
                            Console.WriteLine("Invalid file\n ");
                        }
                        
                    }

                }
                else if(selection == 2)
                {
                    Console.WriteLine("Enter path of a XML file or type default"); 
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        XMLDseralizer xmlds = new XMLDseralizer(); 
                        xmlds.setdeserilizer(DEFAULTCURFILE + XML, cu);
                    }
                    else
                    {
                        XMLDseralizer xmlds = new XMLDseralizer();

                        try
                        {
                            xmlds.setdeserilizer(command, cu); 
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file\n ");
                        }

                    }
                }
                else if (selection == 3) // write all good
                {
                    Console.WriteLine("Enter path of Json file or type default"); 
                    command = Console.ReadLine();
                    if(command.Equals("default"))
                    {
                        JsonSeralizer jsonSer = new JsonSeralizer();
                        jsonSer.setSerilizer(DEFAULTCURFILE + JSON, cu);
                    }
                    else
                    {
                        JsonSeralizer jsonSer = new JsonSeralizer();
                        try {
                            jsonSer.setSerilizer(command, cu);  
                        } catch (IOException e)
                        {
                            Console.WriteLine("Invalid file name\n");
                        }
                        
                    }

                }
                else if (selection == 4) // xml write cu
                {
                    Console.WriteLine("Enter path of XML file or type default"); 
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        MyXMLSerilizer xmlSer = new MyXMLSerilizer();
                        xmlSer.setSerilizer(DEFAULTCURFILE + XML, cu);
                    }
                    else
                    {
                        MyXMLSerilizer xmlSer = new MyXMLSerilizer(); 
                        try
                        {
                            xmlSer.setSerilizer(command, cu);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file name\n");
                        }

                    }
                }
                else if (selection == 5) // display
                {
                    Console.WriteLine("");
                    Console.WriteLine(cu.ToString() + "\n");
                    
                }
                else if (selection == 6)
                {
                    Console.WriteLine("Enter path of a JSON file or type default");
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        JsonDseralizer jds = new JsonDseralizer();  
                        jds.setdeserilizer(DEFAULTLANGFILE + JSON, lang);
                    }
                    else
                    {
                        JsonDseralizer jds = new JsonDseralizer(); 

                        try
                        {
                            jds.setdeserilizer(command, lang);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file ");
                        }

                    }
                }
                else if (selection == 7)
                {

                    Console.WriteLine("Enter path of a XML file or type default"); 
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        XMLDseralizer xmlds = new XMLDseralizer(); 
                        xmlds.setdeserilizer(DEFAULTLANGFILE + XML, lang); 
                    }
                    else
                    {
                        XMLDseralizer xmlds = new XMLDseralizer();  

                        try
                        {
                            xmlds.setdeserilizer(command, lang); 
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file ");
                        }

                    }

                }
                else if (selection == 8)
                {
                    Console.WriteLine("Enter path of Json file or type default");
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        JsonSeralizer jsonSer = new JsonSeralizer();
                        jsonSer.setSerilizer(DEFAULTLANGFILE + JSON, lang); 
                    }
                    else
                    {
                        JsonSeralizer jsonSer = new JsonSeralizer();
                        try
                        {
                            jsonSer.setSerilizer(command, lang);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file name\n");
                        }

                    }
                }
                else if (selection == 9)
                {
                    Console.WriteLine("Enter path of XML file or type default");
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        MyXMLSerilizer xmlSer = new MyXMLSerilizer();
                        xmlSer.setSerilizer(DEFAULTLANGFILE + XML, lang); 
                    }
                    else
                    {
                        MyXMLSerilizer xmlSer = new MyXMLSerilizer();
                        try
                        {
                            xmlSer.setSerilizer(command, lang); 
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file name\n");
                        }

                    }
                }
                else if (selection == 10) // display
                {
                    Console.WriteLine();
                    Console.WriteLine(lang.ToString()+ "\n");
                }
                else if (selection == 11)
                {
                    Console.WriteLine("Enter path of a JSON file or type default");
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        JsonDseralizer jds = new JsonDseralizer(); 
                        jds.setdeserilizer(DEFAULTCOUNTRYFILE + JSON, country); 
                    }
                    else
                    {
                        JsonDseralizer jds = new JsonDseralizer(); 

                        try
                        {
                            jds.setdeserilizer(command, country); 
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file ");
                        }

                    }
                }
                else if (selection == 12)
                {
                    Console.WriteLine("Enter path of XML file or type default");
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        XMLDseralizer xmlDeSer = new XMLDseralizer();
                        xmlDeSer.setdeserilizer(DEFAULTCOUNTRYFILE + XML, country);
                    }
                    else
                    {
                        XMLDseralizer xmlDeSer = new XMLDseralizer();
                        try
                        {
                            xmlDeSer.setdeserilizer(command, country); 
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file name\n");
                        }

                    }
                }
                else if (selection == 13) // write json
                {
                    Console.WriteLine("Enter path of Json file or type default"); 
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        JsonSeralizer jsonSer = new JsonSeralizer();
                        jsonSer.setSerilizer(DEFAULTCOUNTRYFILE + JSON, country); 
                    }
                    else
                    {
                        JsonSeralizer jsonSer = new JsonSeralizer(); 
                        try
                        {
                            jsonSer.setSerilizer(command, country); 
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file name\n");
                        }

                    }
                }
                else if (selection == 14)
                {
                    Console.WriteLine("Enter path of XML file or type default");
                    command = Console.ReadLine();
                    if (command.Equals("default"))
                    {
                        MyXMLSerilizer xmlSer = new MyXMLSerilizer();
                        xmlSer.setSerilizer(DEFAULTCOUNTRYFILE + XML, country);
                    }
                    else
                    {
                        MyXMLSerilizer xmlSer = new MyXMLSerilizer();
                        try
                        {
                            xmlSer.setSerilizer(command, country);  
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Invalid file name\n");
                        }

                    }
                }
                else if(selection == 15) // display 
                {
                    Console.WriteLine();
                    Console.WriteLine(country.ToString() + "\n");
                }

                #endregion end of main while loop

                selection = -1; // resets selection 
                command = ""; // resets command

                // no need for 16 because UserSelection will never pass back 
                // just exits in that other loop 
            }

        }

        /// <summary>
        /// menu function, just print outputs
        /// </summary>

        #region fuctions for main

        static void PrintMenu()
        {

            Console.WriteLine("Country Menu");
            Console.WriteLine("------------");
            Console.WriteLine("1  - Read Currency from JSON file");
            Console.WriteLine("2  - Read Currency fomr XML file");
            Console.WriteLine("3  - Write Currency to JSON file");
            Console.WriteLine("4  - Write Currency to XML file");
            Console.WriteLine("5  - Display Currency data on screen");
            Console.WriteLine("6  - Read Language from Json file");
            Console.WriteLine("7  - Read Language from XML file");
            Console.WriteLine("8  - Write Language to JSON file");
            Console.WriteLine("9  - Write Language to XML file");
            Console.WriteLine("10 - Display Language data on screen");
            Console.WriteLine("11 - Read Country from JSON file");
            Console.WriteLine("12 - Read Country from XML file");
            Console.WriteLine("13 - Write Country to Json file");
            Console.WriteLine("14 - Write Country to XML file");
            Console.WriteLine("15 - Display Country data on screen");
            Console.WriteLine("16 - Exit");
            Console.WriteLine("Enter Choice:");

        }

        

        /// <summary>
        /// returns the selection the user made and catches 
        /// jibberish the might have input 
        /// </summary>
        /// <returns></returns>
        /// 

       

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
                catch(FormatException e)
                {
                    Console.WriteLine("Invalid choice! type 16 to exit");
                }

                if(selection == 16)
                {
                    Environment.Exit(-1);
                }

                for(int i = 0; i < 16;i++)
                {
                    if(selection == i)
                    {
                        return i;
                    }
                }

            }

        }
        #endregion end of functions for main
    }
}
