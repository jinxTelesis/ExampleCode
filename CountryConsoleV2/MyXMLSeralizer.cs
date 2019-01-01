using System;
using hwk2Library_Andre_lussier;
using System.Runtime.Serialization; // dll for Json
using System.IO;

//*****************************************
// File MyXMLSeralizer 
//
// Purpose: this serailizers 3 different types to XML
//
// hope to rewrite this for proper c# reflection standards once i know them
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*****************************************


namespace MyXMLSerNamespace
{
   public class MyXMLSerilizer
   {

        #region MyXMLSerilizer variables
        private String filename;
        private FileStream writer;
        private DataContractSerializer ser;
        private Currency curP;
        private Language langP;
        private Country countryP; 
        #endregion end of MyXMLSerilizer variables

        /// <summary>
        /// default constructor main purpose is to give 
        /// reference/pointers a value for gettype
        /// </summary>

        public MyXMLSerilizer()
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


        #region MyXMLSerializer methods

        public void setSerilizer(String filename, Object o)
        {
            this.filename = filename;

            writer = new FileStream(filename, FileMode.Create,
                FileAccess.Write);

            if (o.GetType() == curP.GetType())
            {
                o = (Currency)o;
                ser = new DataContractSerializer(typeof(Currency));
                ser.WriteObject(writer, o);
                writer.Close();
            }

            if (o.GetType() == langP.GetType())
            {
                o = (Language)o;
                ser = new DataContractSerializer(typeof(Language));
                ser.WriteObject(writer, o);
                writer.Close();
            }

            if (o.GetType() == countryP.GetType())
            {
                o = (Country)o;
                ser = new DataContractSerializer(typeof(Country));
                ser.WriteObject(writer, o);
                writer.Close();
            }


        }

        #endregion end of MyXMLSerilizer methods
    }

}


