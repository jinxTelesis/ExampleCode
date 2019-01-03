using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using hwk2Library_Andre_lussier; // my dll 
using Microsoft.Win32;

//*************************************************************************
//
//  File: MainWindow.xaml.cs
//
//  Purpose: Main window C# Source code. Stores all the data after it is loaded
//  from json or the database. On window loading the program reads all the files in
//  CountryTable database. If the user selects a json file the program will delete the 
//  entire database and replace it with the data stored in the json code. 
//  The program will also display all the country names in a Listbox
//  if the user selects a given country in the Listbox the texts boxes on the right of the
//  Listbox will display 5 attributes of that country, Name, Capitial, Region, Subregion and Population.
//  There are many minor aspects of the program left out of this description
//
//
//  Written By: Andre Lussier
//
//  Compliler: Visual Studios 2017
//
//****************************************************************************


namespace CountryConsole5DBAndreLussier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region variables for MainWindow class

        List<Country> countryList = new List<Country>();
        //string currentFile = "C:\\Users\\dre\\Desktop\\countries_for_hwk\\countries_for_hwk.json";
        //Country tempCountry;
        List<String> nameList = new List<string>();
        List<String> capitalList;
        List<String> regionList;
        List<String> subregionList;
        List<int> populationList;

        string connString = @"server=(LocalDB)\MSSQLLocalDB;" +
                "integrated security=SSPI;" +
                "database=CountryDB;" +
                "MultipleActiveResultSets=True";


        // the deseralizer
        DeserJSON desrJ = new DeserJSON();

        #endregion end of variables for MainWindow class 

        #region MainWindow Initialization 

        //***********************************
        // Method: MainWindow
        //
        // Purpose: window initialization
        //***********************************

        public MainWindow()
        {

            InitializeComponent();
        }

        #endregion MainWindow Initialization end

        // please ignore these clicked by mistake at some point
        #region missclick events


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CountryListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void CountryListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        #endregion end of missclick events

        #region methods start

        
        //***********************************
        // Method: Window_Loaded
        //
        // Purpose: Loading base data into the window
        //
        // Starts by opening SqlConnection, 
        // connString is global and stores the database name and settings,
        // first statement selects all data in CountryTable.
        // Initializes 4 lists, 5th is initalized at the top.
        // Then the reader which gets the apporiate data types base on the
        // database.
        // last it closes the connection
        // 
        //***********************************

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // opens connection
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();


            // the sql statement
            string sql = "SELECT * FROM CountryTable";
            SqlCommand command = new SqlCommand(sql, sqlConn);

            SqlDataReader reader = command.ExecuteReader();

            int fieldCount = reader.FieldCount;
            
            Console.WriteLine("this is fieldCount " + fieldCount);

            // list initalization
            capitalList = new List<string>();
            regionList = new List<string>();
            subregionList = new List<string>();
            populationList = new List<int>();

            // checks if that reader has rows
            // then reads all 5 columns into lists
            if (reader.HasRows)
            {

                while(reader.Read())
                {

                    nameList.Add((string)reader["Name"]);
                    capitalList.Add(reader.GetString(1));
                    regionList.Add(reader.GetString(2));
                    subregionList.Add(reader.GetString(3));
                    populationList.Add(reader.GetInt32(4));


                }
            }

            // fills the ListBox
            // then closes the connection
            CountryListBox.ItemsSource = nameList;
            sqlConn.Close();

        }


        // about 
        //***********************************
        // Method: MenuItem_Click
        //
        // Purpose: Displays the about click window
        // Has two strings containing the data for the MessageBox
        // Creates MessageBox with just an ok button
        // Displays the window does nothing with the results just closes
        //***********************************

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string msgTitleText = "About Country GUI";
            string msgText = "Country GUI \n Version 2.0 \n Written by Andre Lussier";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(msgText, msgTitleText, button);
        }


        // import
        //***********************************
        // Method: MenuItem_Click_1
        //
        // Purpose: This is the import menu item that allows the user to import a json
        // file. It starts with an OpenFileDialog to get the file, It Limits the types
        // to json makes sure the filename is there if so, clears the coutryList which may hold
        // previous json files then desearlizes the json file based on the user selection.
        // then the database data is deleted before the main loop populates everything
        // into the database. It uses the parameter method to avoid issues with comment 
        // characters causes issues 
        //***********************************
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "JSON files (*.json) | *.json";
            openFileDialog.Title = "Open Countries From JSON";

            

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                // checks for valid file condtions
                if (fileName != null || fileName != "")
                {
                    countryList.Clear();
                    DeserJSON desrJ = new DeserJSON();


                    // catches serilization error 
                    try
                    {
                        countryList = desrJ.serDataAndReturn(fileName, countryList);
                    }
                    catch (Exception ex) { ex.ToString(); }

                    //filenameTextbox.Text = fileName;

                }

            }

            string sqlDelete = "DELETE FROM CountryTable";

            // code to delete the previous database data
            SqlConnection sqlConn5;
            sqlConn5 = new SqlConnection(connString);
            sqlConn5.Open();

            SqlCommand commandDelete = new SqlCommand(sqlDelete, sqlConn5);
            int rowsAffected = commandDelete.ExecuteNonQuery();
            Console.WriteLine("this is the number of rows deleted" + rowsAffected);

            // end of delete code 
            string nameStr = "";
            string capitalStr = "";
            string regionStr = "";
            string subregionStr = "";
            string popStr = "";
            string sqlInsert = "";

            // connection for data insert
            SqlConnection sqlConn2;
            sqlConn2 = new SqlConnection(connString);
            sqlConn2.Open();



            SqlCommand commandInsert = new SqlCommand(sqlInsert, sqlConn2);
            int rowAffected = 0;

            // main loop to read data from the json populated country list 
            // then insert the data into the country database
            for (int i = 0; i < countryList.Count();i++)
            {
                nameStr = countryList[i].Name;
                capitalStr = countryList[i].Capitial;
                regionStr = countryList[i].Region;
                subregionStr = countryList[i].Subregion;
                popStr = Convert.ToString(countryList[i].Population);

                sqlInsert = string.Format("INSERT INTO CountryTable" + "(NAME, Captial, Region, Subregion, Population) Values"
                + "(@param1, @param2, @param3, @param4, @param5)");

                commandInsert = new SqlCommand(sqlInsert, sqlConn2);
                commandInsert.Parameters.Add(new SqlParameter("@param1", nameStr));
                commandInsert.Parameters.Add(new SqlParameter("@param2", capitalStr));
                commandInsert.Parameters.Add(new SqlParameter("@param3", regionStr));
                commandInsert.Parameters.Add(new SqlParameter("@param4", subregionStr));
                commandInsert.Parameters.Add(new SqlParameter("@param5", popStr));


                rowAffected = commandInsert.ExecuteNonQuery();
            }

            Console.WriteLine("this is the number of rows affected " + rowAffected);
            sqlConn2.Close();


        }


        
        // File exit
        //***********************************
        // Method: MenuItem_Click_2
        //
        // Purpose: close the application
        // if the user selects this menu item
        //***********************************
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // about 
        //***********************************
        // Method: CountryListBox_SelectionChanged
        // 
        //
        // Purpose: Gets the current selected item in the ListBox
        // Then will populate the five text boxes to the right of the CountryListBox
        // Based on the info from the database, that data is read in at WindowLoaded
        //***********************************


        private void CountryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index3 = CountryListBox.SelectedIndex;

            NameTextBox.Text = nameList[index3];
            CapitalTextBox.Text = capitalList[index3];
            RegionTextBox.Text = regionList[index3];
            SubregionTextBox.Text = subregionList[index3];
            PopulationTextBox.Text = Convert.ToString(populationList[index3]);

        }
    }

    #endregion methods end 
}
