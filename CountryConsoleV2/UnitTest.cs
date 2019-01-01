using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//********************************************************************
//
// Filename UnitTest.cs
//
//
// Purpose: Contains class definition fo CountryAppUnitTesting
// which containts classes Language Currency and Country
// UnitTest does what the name indictes and makes sure 
// all the methods and properties run correctly and bug free
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
// 
//********************************************************************


namespace hwk2Library_Andre_lussier
{
    public class CountryAppUnitTesting
    {
        

        /// <summary>
        /// Default constructor has just an invoked indicator
        /// </summary>

        public CountryAppUnitTesting()
        {
            Console.WriteLine("invoked");
        } // default constructor class has no members variables not sure what to put -
        // some languages have issues when you don't have a default constructor -
        //but ones with more args so put it for safety till i'm informed about c#

        /// <summary>
        /// second constructor takes in a string to a custom invocation message
        /// 
        /// </summary>
       

        public CountryAppUnitTesting(string s)
        {
            Console.WriteLine(s);
        }


        /// <summary>
        /// Method: UnitTestCurrency
        /// 
        /// Purpose: automatically test cheack of the properties for
        /// the class currency
        /// as the class name suggest it is a unit test
        /// 
        /// </summary>

        public void UnitTestCurrency()
        {
            #region variables and setup of unit test
            Currency curTest = new Currency();
            string testCode = "blank";
            string testName = "blank1";
            string testSymbol = "blank2";

            curTest.Code = testCode;
            curTest.Name = testName;
            curTest.Symbol = testSymbol;

            #endregion

            #region unit test for Currency

            if (curTest.Code == testCode)
            {
                Console.WriteLine("Currency code Property: Pass");
            }
            else
            {
                Console.WriteLine("Currency code Property: FAIL!");
            }

            if (curTest.Name == testName)
            {
                Console.WriteLine("Currency name Property: Pass");
            }
            else
            {
                Console.WriteLine("Currency name Property: FAIL!");
            }

            if (curTest.Symbol == testSymbol)
            {
                Console.WriteLine("Currency Symbol Property: Pass");
            }
            else
            {
                Console.WriteLine("Currency symbol Property: FAIL!");
            }

            #endregion
        }

        /// <summary>
        /// Method: UnitTestLanguage
        /// 
        /// Purpose: automatically test cheack of the properties for
        /// the class Language
        /// as the class name suggest it is a unit test
        /// 
        /// </summary>

        public void UnitTestLanguage()
        {
            #region variables and setup for language unit test

            Language langTest = new Language();

            string testName = "Blank";
            string testNativeName = "blahblah";
            string testIso639_1 = "notNotBlank";
            string testIso639_2 = "notNotNotBlank";


            langTest.Name = testName;
            langTest.NativeName = testNativeName;
            langTest.Iso639_1 = testIso639_1;
            langTest.Iso639_2 = testIso639_2;

            #endregion

            #region unit test for Language

            if (langTest.Name == testName)
            {
                Console.WriteLine("Language Name Property: Pass");
            }
            else
            {
                Console.WriteLine("Language Name Property: FAIL!");
            }

            if (langTest.NativeName == testNativeName)
            {
                Console.WriteLine("Language NativeName Property: Pass");
            }
            else
            {
                Console.WriteLine("Language NativeName Property: FAIL!");
            }

            if (langTest.Iso639_1 == testIso639_1)
            {
                Console.WriteLine("Language Iso639_1 Properpty: Pass");
            }
            else
            {
                Console.WriteLine("Language Iso639_1 Properpty: FAIL!");
            }

            if (langTest.Iso639_2 == testIso639_2)
            {
                Console.WriteLine("Language Iso639_2 Property: Pass");
            }
            else
            {
                Console.WriteLine("Language Iso639_2 Property: FAIL!");
            }

            #endregion

        }

        /// <summary>
        /// Method: UnitTestCountry
        /// 
        /// Purpose: automatically test cheack of the properties for
        /// the class Country
        /// as the class name suggest it is a unit test
        /// 
        /// </summary>


        public void UnitTestCountry() {

            #region variables and setup of Country unit test

            Country co = new Country();
           
            string name = "France";
            string capital = "Paris";
            string region = "Europe";
            string subregion = "Northernish Europe";
            double population = 55;

            co.Name = name;
            co.Capitial = capital;
            co.Region = region;
            co.Subregion = subregion;
            co.Population = population;

            #endregion

            #region unit test for Country

            if (co.Name == name)
            {
                Console.WriteLine("Language Name Property: Pass");
            }
            else
            {
                Console.WriteLine("Language Name Property: FAIL!");
            }

            if (co.Capitial == capital)
            {
                Console.WriteLine("Language Capitial Property: Pass");
            }
            else
            {
                Console.WriteLine("Language Capitial Property: FAIL!");
            }

            if (co.Region == region)
            {
                Console.WriteLine("Language Region Properpty: Pass");
            }
            else
            {
                Console.WriteLine("Language Region Properpty: FAIL!");
            }

            if (co.Subregion == subregion)
            {
                Console.WriteLine("Language Subregion Property: Pass");
            }
            else
            {
                Console.WriteLine("Language Subregion Property: FAIL!");
            }

            if (co.Population == population)
            {
                Console.WriteLine("Language Population Property: Pass");
            }
            else
            {
                Console.WriteLine("Language Population Property: FAIL!");
            }

            #endregion
        }


    }
}
