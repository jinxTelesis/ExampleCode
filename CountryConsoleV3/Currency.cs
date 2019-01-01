using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Runtime.Serialization;

//******************************************************************************
// File: Currency.cs 
//
// purpose: contains class definition of Currency
//          such as currency code, name and symbols
//          dll file for Console app used in UnitTest
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//******************************************************************************


namespace hwk2Library_Andre_lussier
{
    [DataContract]
    public class Currency
    {
        #region private member variables
        private string code;
        private string name;
        private string symbol;

        #endregion
        //***********************
        // default constructor
        // sets values to U.S. defaults
        //
        //****************************
        public Currency()
        {
            this.code = "1"; // personally perfer always using this not matter the language
            this.name = "Dollars";
            this.symbol = "$";

        }

        #region properties of Currency

        //*********************************************
        // properties for Code shorthand getter/setter
        //*********************************************
        [DataMember(Name="code")]
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

        //*********************************************
        // properties for Name shorthand getter/setter
        //*********************************************
        [DataMember(Name="name")]
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

        //*********************************************
        // properties for Symbol shorthand getter/setter
        //*********************************************
        [DataMember(Name="symbol")]
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

        //******************************************
        // Method: ToString
        //
        // Purpose: to show code, name and symbol
        // to a string in an human readable form
        // will print out unknown if null values are found
        /// will not throw exceptions
        /// null conditional check added to values that might not be null
        // overrides object ToString
        //*******************************************

        public override string ToString()
        {
            String s = "";

            if(this.code !=null)
            {
                s += "currency code : " + this.code + "\n";
            }
            else
            {
                s += "currency code : unknown " + "\n";
            }

            if(this.name !=null)
            {
                s += "currency name: " + this.name + "\n";
            }
            else
            {
                s += "currency symbol: unknown " + "\n";
            }

            if(this.symbol !=null)
            {
                s += "currency symbol: " + this.symbol + "\n"; 
            }
            else
            {
                s += "currency symbol: unknown" + "\n\n";
            }

            return s;
        }

        #endregion

    }
}
