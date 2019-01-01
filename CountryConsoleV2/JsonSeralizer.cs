using System;
using hwk2Library_Andre_lussier;
using System.Runtime.Serialization.Json; // dll for Json
using System.IO;

//*****************************************
// File JsonSeralizer
//
// Purpose: this serilizies 3 user defined types automatically to json when
// hope to rewrite this for proper c# reflection standards once i know them
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*****************************************


namespace DresSearlizer
{

    public class JsonSeralizer
    {
        #region JsonSeralizer variables
        private String filename;
        private FileStream writer;
        private DataContractJsonSerializer ser;
        private Currency curP; // new Currency();
        private Language langP;// = new Language();
        private Country countryP;// = new Country();

        #endregion Json Seralizer end variables
        /// <summary>
        /// default constructor 
        /// the objects need to be created to get the types in the following code
        /// curP.GetType() won't work without the type there
        /// langP.GetType() won't work without the type there
        /// countryP.getType() won't work without the the type there
        /// </summary>

        public JsonSeralizer()
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

        #region Methods for JsonSeralizer

        public void setSerilizer(String filename, Object o)
        {
            this.filename = filename;

            writer = new FileStream(filename, FileMode.Create,
                FileAccess.Write);

            if (o.GetType() == curP.GetType())
            {
                o = (Currency)o;
                ser = new DataContractJsonSerializer(typeof(Currency));
                ser.WriteObject(writer, o);
                writer.Close();
            }

            if(o.GetType() == langP.GetType())
            {
                o = (Language)o;
                ser = new DataContractJsonSerializer(typeof(Language));
                ser.WriteObject(writer, o);
                writer.Close();
            }

            if(o.GetType() == countryP.GetType())
            {
                o = (Country)o;
                ser = new DataContractJsonSerializer(typeof(Country));
                ser.WriteObject(writer, o);
                writer.Close();
            }


            
        }

        #endregion end of methods for JsonSeralizer

    }

}


