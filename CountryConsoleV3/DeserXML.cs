using System;
using System.Collections.Generic;
using System.Text;
using hwk2Library_Andre_lussier;
using System.Runtime.Serialization;
using System.IO;


//***********************************************
// File: DeserXML.cs
//
// XML deserilization program 
//
// Purpose: Abstract / Encapsulate some of the setup of 
//          the XML deserailization process to declutter the  
//          driver class, takes in a file provided by user / driver
//          and the Country list data type and returns the List populated
//          with country data.
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*************************************************

namespace CountryConsole3AndreLussier
{
    public class DeserXML
    {
        #region DserXML private variables

        private string fileName;
        private FileStream reader;
        private StreamReader streamReader;

        #endregion DeserXML end of variables

        /// <summary>
        /// default constructor can't really do much new files and country objects 
        /// might be passed in after object creation so everything set there
        /// </summary>

        #region constructor region
        public DeserXML()
        {
            
        }
        #endregion end of constructor region


        /// <summary>
        /// Method : SerDataAndReturn
        /// 
        /// Purpose: XML only deseralizer 
        /// 
        /// 
        /// takes filename and Country list data type
        /// opens a reader then a stream reader for UTF8 encoding
        /// reads entire stream puts it into byte array form
        /// puts the byteArray into a memory stream
        /// creates a read serializer then reads or deseralizes to cpountryList
        /// then closes the memory stream returns countryList 
        /// </summary>
        /// <param name="fileName">passed in file name for deseralization</param>
        /// <param name="countryList">the country list object containing lists of currencies and languages</param>
        /// <returns></returns>
        /// 

        #region DeserXML methods and properties this is not the constructor

        public List<Country> SerDataAndReturn(String fileName, List<Country> countryList) // wanted this to be a method with a call
        {
            reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            streamReader = new StreamReader(reader, Encoding.UTF8);
            string jsonStorage = streamReader.ReadToEnd();
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonStorage);
            MemoryStream memStream = new MemoryStream(byteArray);
            DataContractSerializer readSerializer;
            readSerializer = new DataContractSerializer(typeof(List<Country>));
            countryList = (List<Country>)readSerializer.ReadObject(memStream);
            memStream.Close();
            return countryList; 
            
        }

        /// <summary>
        /// Property: FileName
        /// 
        /// Purpose: set only property for filename 
        /// </summary>

        public string FileName
        {
            set
            {
                this.fileName = value;
            }
        }

        #endregion end DeserXML methods and properties


    }
}
