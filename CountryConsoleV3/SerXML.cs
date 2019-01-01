using System;
using System.Collections.Generic;

using System.Text;
using System.IO;

using System.Runtime.Serialization;
using hwk2Library_Andre_lussier;


//***********************************************
// File: SerXML.cs
//
// XML seralizer class. 
//
// Purpose:   Abstract and encapulsate some of the setup
//            for seralization into a class that can be
//            used by the driver program. Takes a filename from driver
//            and the List<Country> data type and writes to a XML file.
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*************************************************

namespace CountryConsole3AndreLussier
{
    public class SerXML
    {

        #region SerXML variables
        private string fileName; 
        private List<Country> countryList;
        private DataContractSerializer serializer;
        #endregion SerXML end variables

        /// <summary>
        /// Constructor : SerXML
        /// 
        /// XML serializer
        /// takes filename and Country List data type
        /// starts a serializer of type ListCountry
        /// then a memory stream and writes to it
        /// then turns it into a bype array, ENcordes to UTF8
        /// then writes to the file
        /// </summary>

        #region SerXML constructor

        public SerXML(String fileName, List<Country> countryList)
        {
            this.fileName = fileName;
            this.countryList = countryList;
            serializer = new DataContractSerializer(typeof(List<Country>));
            MemoryStream memStream = new MemoryStream();
            serializer.WriteObject(memStream, countryList);
            byte[] byteData = memStream.ToArray();
            string jsonDataStr = Encoding.UTF8.GetString(byteData, 0, byteData.Length);
            StreamWriter streamWrite = new StreamWriter(fileName, false, Encoding.UTF8);
            streamWrite.Write(jsonDataStr);
            streamWrite.Close();
        }

        #endregion SerXML constructor end

        #region SerXML methods and properties

        /// <summary>
        /// Property: FileName
        /// 
        /// Purpose: setter for fileName
        /// </summary>

        public string FileName
        {
            set
            {
                this.fileName = value;
            }
        }

        #endregion SerXML method and properties end

    }
}
