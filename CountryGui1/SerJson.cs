using System;
using System.Collections.Generic;

using System.Text;

using System.IO;
using hwk2Library_Andre_lussier;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

//***********************************************
// File: SerJson.cs
//
// JSON seralizer class.
//
// Purpose: Abstract / encapulsate some of the setup
//          for seralization into a class that can be
//          used by the driver program. Takes a filename from driver
//          and the List<Country> data type and writes to a JSON file.
//
// Written By: Andre Lussier
// 
// Compiler: Visual Studios 2017 
//
//*************************************************

namespace CountryGUIAndreLussierNameSpace
{
    public class SerJson
    {

        #region SerJson variables
        private string fileName; //
        private List<Country> countryList;
        private DataContractJsonSerializer serializer;
        #endregion end of SerJson variables


        /// <summary>
        /// Constructor: SerJson
        /// 
        /// JSON serializer
        /// takes filename and Country List data type
        /// starts a serializer of type ListCountry
        /// then a memory stream and writes to it
        /// then turns it into a bype array, Encordes to UTF8
        /// then writes to the file
        /// </summary>

        #region SerJson Constructor

        public SerJson(String fileName, List<Country> countryList)
        {
            this.fileName = fileName;
            this.countryList = countryList;
            serializer = new DataContractJsonSerializer(typeof(List<Country>));
            MemoryStream memStream = new MemoryStream();
            serializer.WriteObject(memStream, countryList);
            byte[] byteData = memStream.ToArray();
            string jsonDataStr = Encoding.UTF8.GetString(byteData, 0, byteData.Length);
            StreamWriter streamWrite = new StreamWriter(fileName, false, Encoding.UTF8);
            streamWrite.Write(jsonDataStr);
            streamWrite.Close();

        }

        #endregion end SerJson Constructor

        #region SerJson methods and properties

        /// <summary>
        /// Method: returns currency countryList
        /// 
        /// Purpose: returns datatype highlighted by returns
        /// </summary>
        /// <returns>List<Country> deserailized from file</Country></returns>

        public List<Country> DataReturn() // wanted this to be a method with a call
        {

            return this.countryList;
        }

        /// <summary>
        /// Property: FileName 
        /// 
        /// Purpose: only has setterfor fileName
        /// </summary>

        public string FileName
        {
            set
            {
                this.fileName = value;
            }
        }

        #endregion end SerJson methods and properties

    }
}
