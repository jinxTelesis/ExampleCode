using System;
using hwk2Library_Andre_lussier;
using System.Runtime.Serialization.Json; // dll for Json
using System.IO;

//*****************************************
// File JsonDseralizer
//
// Purpose: this deserializes 3 different types to json
// hope to rewrite this for proper c# reflection standards once i know them
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*****************************************

namespace DresDesearlizer {

    public class JsonDseralizer
    {


        #region JsonDeseralizer variables
        private String filename;
        private FileStream reader;
        private Currency curP;// these are for the type comparison, think this should be reflections? 
        private Language langP;// but I don't know about that yet, just coded a lot of dynamic type checking
        private Country countryP; // python so this felt right
        #endregion end of JsonDeseralizer variables

        /// <summary>
        /// default constructor main purpose is to give 
        /// reference/pointers a value for gettype
        /// </summary>

        public JsonDseralizer()
        {
            this.curP = new Currency();
            this.langP = new Language();
            this.countryP = new Country();
        }

        /// <summary>
        /// control statement to form better decoupled code
        /// 
        /// </summary>
        /// <param name="filename">takes the filename location the user passes in </param> 
        /// <param name="o"> takes the object type determined by constrol states
        /// will be either Currency, Language or Country
        /// 
        /// if(o.GetType()== curP.GetType()) makes the runtime determination for late
        /// 
        /// </param>
        /// 
        #region JsonDeserializer methods

        public void setdeserilizer(String filename, Object o)
        {
            this.filename = filename;

            reader = new FileStream(filename, FileMode.Open, FileAccess.Read);

            if (o.GetType() == curP.GetType())
            {
                o = (Currency)o;
                DataContractJsonSerializer inputSerializer;
                inputSerializer = new DataContractJsonSerializer(typeof(Currency));

                curP = (Currency)inputSerializer.ReadObject(reader);
                reader.Close();


            }

            if (o.GetType() == langP.GetType())
            {
                o = (Language)o;
                DataContractJsonSerializer inputSerializer;
                inputSerializer = new DataContractJsonSerializer(typeof(Language));
                langP = (Language)inputSerializer.ReadObject(reader);
                reader.Close();

            }

            if (o.GetType() == countryP.GetType())
            {
                o = (Country)o;
                DataContractJsonSerializer inputSerializer;
                inputSerializer = new DataContractJsonSerializer(typeof(Country));
                countryP = (Country)inputSerializer.ReadObject(reader);
                reader.Close();

            }


        }

        #endregion of JsonDseralizer methods

    }

}





