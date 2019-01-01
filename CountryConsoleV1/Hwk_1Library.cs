using System;

namespace Hwk_1Library
{
    public class Currency
    {
        // felt region was self descriptive enough for most areas
        #region private member variables 
        private string code;
        private string name;
        private string symbol;


        #endregion

        // default constructor
        // needed to add public access in other classes methods
        // changed to interanal 
        public Currency()
        {
            this.code = "1"; // personally perfer always using this not matter the language
            this.name = "Dollars";
            this.symbol = "$";

        }

        #region properties of Currency

        public string Code
        {

            get
            {
                return this.code;
            }

            set
            {
                this.code = value;
            }

        }

        public string Name
        {

            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }

        }

        public string Symbol
        {

            get
            {
                return this.symbol;
            }
            set
            {
                this.symbol = value;
            }

        }

        #endregion

        #region methods of Currency
        public override string ToString()
        {
            return "The current currency is set to :" + this.code + "\n" +
                "The current currency name is set to :" + this.name + "\n" +
                "The current currency symbol is : " + this.symbol;
        }

        #endregion

    }

    // default constructor
    // needed to add public access in other classes methods
    // changed to interanal 

    public class Language
    {
        #region private member variables
        private string name;
        private string nativeName;
        private string iso639_1;
        private string iso639_2;

        #endregion

        public Language()
        {
            this.name = "English";
            this.nativeName = "English2";
            this.iso639_1 = "en";
            this.iso639_2 = "es";
        }

        #region properties of Language

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string NativeName
        {
            get
            {
                return this.nativeName;
            }

            set
            {
                this.nativeName = value;
            }
        }

        public string Iso639_1
        {
            get
            {
                return this.iso639_1;
            }

            set
            {
                this.iso639_1 = value;
            }
        }

        public string Iso639_2
        {
            get
            {
                return this.iso639_2;
            }

            set
            {
                this.iso639_2 = value;
            }
        }

        #endregion

        #region methods of Language

        public override string ToString()
        {
            return "The language name is : " + this.name + "\n"
                + "The nativeName is : " + this.nativeName + "\n"
                + "iso639_1 is set to : " + this.iso639_1 + "\n"
                + "iso639_2 is set to : " + this.iso639_2;
        }

        #endregion

    }

    public class CountryAppUnitTesting
    {
        #region private member variables

        #endregion

        public CountryAppUnitTesting()
        {
            Console.WriteLine("invoked");
        } // default constructor class has no members variables not sure what to put -
        // some languages have issues when you don't have a default constructor -
        //but ones with more args so put it for safety till i'm informed about c#

        public CountryAppUnitTesting(string s)
        {
            Console.WriteLine(s);
        }

        #region properties of Language

        #endregion

        #region methods of Language

        public void UnitTestCurrency()
        {
            Currency curTest = new Currency();
            string testCode = "blank";
            string testName = "blank1";
            string testSymbol = "blank2";

            curTest.Code = testCode;
            curTest.Name = testName;
            curTest.Symbol = testSymbol;

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

        }

        public void UnitTestLanguage()
        {
            Language langTest = new Language();

            string testName = "Blank";
            string testNativeName = "blahblah";
            string testIso639_1 = "notNotBlank";
            string testIso639_2 = "notNotNotBlank";


            langTest.Name = testName;
            langTest.NativeName = testNativeName;
            langTest.Iso639_1 = testIso639_1;
            langTest.Iso639_2 = testIso639_2;

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

        }

        #endregion

    }

}
