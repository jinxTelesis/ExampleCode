using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

//*************************************************
// File: Country.cs
//
// Purpose: Contains country information with properties.
//          The class also contains via composition
//          the currency and language classes as lists
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*************************************************

namespace hwk2Library_Andre_lussier
{
    [DataContract]
    public class Country
    {
        /// <summary>
        /// the data members currency and language are user defined
        /// classes within the same project 
        /// the Country class contains list of these user defined class
        /// which can be found in this dll
        /// </summary>
        #region Private member variables of Country
        private string name;
        private string capital;
        private string region;
        private string subregion;
        private double population;
        private List<Currency> currencies;
        private List<Language> languages;
        #endregion end of Private member variables of Country
        /// <summary>
        /// Default constructor
        /// 
        /// Contains two user defined classe as well as the classes own properties
        /// User defined class currencies and languages
        /// </summary>

        public Country()
        {
            this.name = "United States";
            this.capital = "Washington DC";
            this.region = "North America";
            this.subregion = "Blank";
            this.population = 300;
            this.currencies = new List<Currency>(); // test both
            this.languages = new List<Language>();

        }




        /// <summary>
        ///  Properties for Country
        ///  basically getters and setter shorthand
        ///  for name
        /// </summary>
        /// 
        #region properties for Country



        [DataMember(Name = "name")]
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


        /// <summary>
        ///  Properties for Country
        ///  basically getters and setter shorthand
        ///  for captial
        /// </summary>
        /// 

        [DataMember(Name = "capital")]
        public string Capitial
        {
            get
            {
                return this.capital;
            }

            set
            {
                this.capital = value;
            }

        }

        /// <summary>
        ///  Properties for Country
        ///  basically getters and setter shorthand
        ///  for Region
        /// </summary>

        [DataMember(Name = "region")] // this one worked 
        public string Region
        {

            get
            {
                return this.region;
            }

            set
            {
                this.region = value;
            }

        }

        /// <summary>
        ///  Properties for Country
        ///  basically getters and setter shorthand
        ///  for Subregion
        /// </summary>

        [DataMember(Name="subregion")]
        public string Subregion
        {
            
            get
            {
                return this.subregion;
            }

            set
            {
                this.subregion = value;
            }

        }

        /// <summary>
        ///  Properties for Country
        ///  basically getters and setter shorthand
        ///  for Population
        /// </summary>

        [DataMember(Name="population")]
        public double Population
        {

            get
            {
                return this.population;
            }

            set
            {
                this.population = value;
            }

        }

        /// <summary>
        ///  Properties for Country
        ///  
        ///  Purpose: basically getters and setter shorthand
        ///  for the composition object List currencies of type Currency
        /// </summary>

        [DataMember(Name = "currencies")]
        public List<Currency> Currencies
        {

            get
            {
                return this.currencies;
            }

            set
            {
                this.currencies = value;
            }
        }

        /// <summary>
        ///  Property for Country
        ///  
        ///  Purpose: basically getters and setter shorthand
        ///  for the composition object list lang of type Language
        /// </summary>

        [DataMember(Name = "languages")]
        public List<Language> Languages
        {

            get
            {
                return this.languages;
            }
            set
            {
                this.languages = value;
            }
        }

        /// <summary>
        ///  Method: ToString 
        ///  
        /// Purpose: Override of the objects default
        /// sets string to human readable form for name, captial
        /// subregion, population. calls currecy's ToString and languages.ToString
        /// for brevity
        /// realize some of the listed data was not declared to be null
        /// but thought it was more robust to always be able to address
        /// although null for the country name seems more questionable
        /// 
        /// </summary>

        #endregion end of properties for Country

        #region Methods of Country

        public override string ToString() // need to do null checking
        {
            String s = "";

            if (this.name != null)
            {
                s += "Country: " + this.name + "\n";
            }
            else
            {
                s += "Country: unknown \n";
            }

            if (this.capital != null)
            {
                s += "Capital: " + this.capital + "\n";
            }
            else
            {
                s += "Capital: unknown" + this.name + "\n";
            }

            if (this.region != null)
            {
                s += "region: " + this.region + "\n";
            }
            else
            {
                s += "region: unknown \n";
            }

            if (this.subregion != null)
            {
                s += "subregion: " + this.subregion + "\n";
            }
            else
            {
                s += "subregion: unknown \n";
            }

            s += "population " + this.population + "\n\n";

            foreach (Currency x in currencies)
            {
                s += x.ToString();
            }

            foreach (Language y in languages)
            {
                s += y.ToString();
            }

            s+= "End of " + Name + "'s " + "languages and currencies\n----------------------\n";
            return s;

        }

        #endregion end of Methods for Country

    }
}
