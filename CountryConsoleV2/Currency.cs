using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // need to add dll reference
using System.Runtime.Serialization;

//******************************************************************************
// File: Currency.cs 
//
// purpose: contains class definition of Currency
// such as currency code, name and symbols
// dll file for Console app used in UnitTest
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
        // overrides object ToString
        //*******************************************

        public override string ToString()
        {
            return "The current currency is set to :" + this.code + "\n" +
                "The current currency name is set to :" + this.name + "\n" +
                "The current currency symbol is : " + this.symbol;
        }

        #endregion

    }
}
