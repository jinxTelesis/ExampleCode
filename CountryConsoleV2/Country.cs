using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

//*************************************************
// File: Country.cs
//
// Purpose: Contains country information
// with properties.
// The class also contains via composition
// the currency and language classes 
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
        /// 
        /// </summary>
        #region Private member variables of Country
        private string name;
        private string capital;
        private string region;
        private string subregion;
        private double population;
        private Currency currency;
        private Language language;
        #endregion end of Private member variables of Country
        /// <summary>
        /// Default constructor
        /// 
        /// Contains two user defined classe as well as the classes own properties
        /// User defined class Currency and Language
        /// </summary>

        public Country()
        {
            this.name = "United States";
            this.capital = "Washington DC";
            this.region = "North America";
            this.subregion = "Blank";
            this.population = 300;
            this.currency = new Currency();
            this.language = new Language();
        }

        /// <summary>
        /// Constructor that takes user defined object arguments
        /// changes what data is used for the composition objects
        /// 
        /// </summary>
        /// <param name="cur">parameter to set the currency object</param> 
        /// <param name="lang">parameter to set the language object</param> 

        public Country(Currency cur, Language lang)
        {
            this.name = "United States";
            this.capital = "Washington DC";
            this.region = "North America";
            this.subregion = "Blank";
            this.population = 300;
            this.currency = cur;
            this.language = lang;
        }
        /// <summary>
        /// Constructor that takes full input on each of the class members variables
        /// as well as object for the composition 
        /// </summary>
        /// <param name="name">sets name parameter</param> 
        /// <param name="cap">sets captial parameter</param>  
        /// <param name="reg">sets region parameter</param> 
        /// <param name="sub">sets subregion paramenter</param> 
        /// <param name="pop">sets population parameter</param> 
        /// <param name="cur">sets composition object of type Currency</param> 
        /// <param name="lang">sets composition object of type Language</param> 
        /// 


        public Country(String name, String cap, String reg,
            String sub, double pop, Currency cur, Language lang)
        {
            this.name = name;
            this.capital = cap;
            this.region = reg;
            this.subregion = sub;
            this.population = pop;
            this.currency = cur;
            this.language = lang;
        }

        /// <summary>
        ///  Properties for Country
        ///  basically getters and setter shorthand
        ///  for name
        /// </summary>
        /// 
        #region properties for Country

        [DataMember(Name="speed")]
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

        [DataMember(Name="capital")]
        public string Capitial
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
        ///  for Region
        /// </summary>

        [DataMember(Name="Region")]
        public string Region
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
        ///  Auto-implemented Properties for Country
        ///  basically getters and setter shorthand
        ///  for the composition object cur of type Currency
        /// </summary>

        [DataMember(Name="currency")]
        public Currency cur { get; set; } =  new Currency();

        /// <summary>
        ///  Auto-implemented Properties for Country
        ///  basically getters and setter shorthand
        ///  for the composition object lang of type Language
        /// </summary>

        [DataMember(Name="language")]
        public Language lang { get; set; } = new Language();

        /// <summary>
        ///  Method: ToString 
        ///  
        /// Purpose: Override of the objects default
        /// sets string to human readable form for name, captial
        /// subregion, population. calls currecy's ToString and languages.ToString
        /// for brevity
        /// 
        /// </summary>

        #endregion end of properties for Country

        #region Methods of Country

        public override string ToString()
        {
            return "Country: " + this.name +
                "Capital: " + this.capital +
                "region: " + this.subregion +
                "subRegion " + this.subregion +
                "population " + this.population +
                currency.ToString() + language.ToString();
 
        }

        #endregion end of Methods for Country

    }
}
