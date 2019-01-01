using System;
using hwk2Library_Andre_lussier;
using System.Runtime.Serialization; // dll for Json
using System.IO;

//*****************************************
// File XMLDSeralizer 
//
// Purpose: this deseralizes 3 different types to XML
// hope to rewrite this for proper c# reflection standards once i know them
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*****************************************


namespace MyXMLDeSerNamespace {

    public class XMLDseralizer
    {

        #region XMLDseralizer variables
        private String filename;
        private FileStream reader;
        //private DataContractJsonSerializer ser;
        private Currency curP; // = new Currency(); // these are for the type comparison, think this should be reflections? 
        private Language langP; // = new Language(); // but I don't know about that yet, just coded a lot of dynamic type checking
        private Country countryP; // = new Country(); // python so this felt right
        #endregion end of XMLDserilizer variables

        /// <summary>
        /// default constructor so it can get the type
        /// the defaults for the data type is irrelivant 
        /// </summary>

        public XMLDseralizer()
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

        #region XMLDserilizer methods

        public void setdeserilizer(String filename, Object o)
        {
            this.filename = filename;

            reader = new FileStream(filename, FileMode.Open, FileAccess.Read);

            if (o.GetType() == curP.GetType())
            {
                o = (Currency)o;
                DataContractSerializer inputSerializer;
                inputSerializer = new DataContractSerializer(typeof(Currency));

                curP = (Currency)inputSerializer.ReadObject(reader);
                reader.Close();


            }

            if (o.GetType() == langP.GetType())
            {
                o = (Language)o;
                DataContractSerializer inputSerializer;
                inputSerializer = new DataContractSerializer(typeof(Language));
                langP = (Language)inputSerializer.ReadObject(reader);
                reader.Close();

            }

            if (o.GetType() == countryP.GetType())
            {
                o = (Country)o;
                DataContractSerializer inputSerializer;
                inputSerializer = new DataContractSerializer(typeof(Country));
                countryP = (Country)inputSerializer.ReadObject(reader);
                reader.Close();

            }

        }

        #endregion end of XMLDserlizter methods 

    }
}


