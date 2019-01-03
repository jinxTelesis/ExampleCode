using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using hwk2Library_Andre_lussier;
using CountryGUIAndreLussierNameSpace;
using Microsoft.Win32;

namespace CountryGUIAndreLussier
{
    //***************************************************************************
    // File: MainWindow.xaml.cs
    // 
    // Purpose: Contains event logic for the MainWindow xaml
    // holds one list of countries from the hwk2 dll file updated to lists
    // this window sets button clicks to deseralize the json data
    // also has button event to start a search based on the data enter 
    // in the country text box, this will search and display data to the
    // other Textboxs and Listviews
    //
    // Written By: Andre Lussier
    //
    // Compiler: Visual Studio 2017
    // **************************************************************************



    // my file location for testing convience
    //C:\Users\dre\Desktop\countries_for_hwk\countries_for_hwk.json



     // class MainWindow contains event logic for 
     // the MainWindow.xaml
     // creates a countryList to store data
     // has button events to start deseralization and search of country
     // will display approriate country data in the various Textboxes

    public partial class MainWindow : Window
    {
        #region variables for MainWindow class

        List<Country> countryList = new List<Country>();
        string currentFile = "C:\\Users\\dre\\Desktop\\countries_for_hwk\\countries_for_hwk.json";
        Country tempCountry;

        #endregion end of variables for MainWindow class 

        // initializes main window

        #region region for MainWindow initalization

        public MainWindow()
        {
            Title = "Country GUI - v1 - Andre Lussier";
            InitializeComponent();
            
        }

        #endregion end of MainWindow initalization

        // events i clicked by accident but am scared to delete 

        #region missclick events

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion end missclick events

        #region event methods 

        // in development i automatically loaded the file
        // that is commented out under the window loaded method

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Country> countryList = new List<Country>();
            
            //DeserJSON desrJ = new DeserJSON();
            //countryList = desrJ.serDataAndReturn(currentFile, countryList);
            //          Console.WriteLine("Displaying entire country list");
            //          if (countryList.Count != 0)
            //          {
            //              foreach (Country x in countryList)
            //              {
            //                  Console.WriteLine(x.ToString());
            //              }
            //          }
        }


        // Button_Click checks if the country name Textbox is empty and if the country list has data
        // if both are true is reads the filename then searches through the country list with a lambda express
        // to find the position if the positon is not -1 it will load the data as long as it does not turn up null
        // the Listviews will then be populated via loops that go up to the count of currencies and languages respectively 
        // if a valid case is not found it will set everything to empty or "" in other words 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(countryNameTextbox.Text != "" && countryList.Count != 0)
            {
                string currentCountry = countryNameTextbox.Text;
                int searchPostion;
                searchPostion = countryList.FindIndex(countryElem => countryElem.Name.Equals(currentCountry));

                if(searchPostion != -1)
                {
                    tempCountry = countryList[searchPostion];
                    nameTextbox.Text = tempCountry.Name;

                    if(tempCountry.Capitial != null)
                    {
                        captialTextBox.Text = tempCountry.Capitial;
                    }

                    if(tempCountry.Region != null)
                    {
                        regionTextbox.Text = tempCountry.Region;
                    }

                    if(tempCountry.Subregion != null)
                    {
                        subregion.Text = tempCountry.Subregion;
                    }

                    if(tempCountry.Population != 0)
                    {
                        double tempD = tempCountry.Population;
                        populationTextbox.Text = tempD.ToString();
                    }

                    // while loop to fill out currencies and languages
                    //ListViewLang.Items.Add(tempCountry.Languages[0].Name);
                    //ListViewCur.Items.Add(tempCountry.Currencies[0].Name);

                    listViewCur.Items.Clear();
                    listViewLang.Items.Clear();

                    for(int i = 0; i < tempCountry.Languages.Count; i++)
                    {
                        
                        if(tempCountry.Languages[i].Name != null)
                        {
                            listViewLang.Items.Add(tempCountry.Languages[i].Name);
                        }
                    }

                    for(int i = 0; i < tempCountry.Currencies.Count; i++)
                    {

                        if(tempCountry.Currencies[i].Name != null)
                        {
                            listViewCur.Items.Add(tempCountry.Currencies[i].Name);
                        }

                    }

                }
                else
                {
                    countryNameTextbox.Text = "";
                    nameTextbox.Text = "";
                    captialTextBox.Text = "";
                    regionTextbox.Text = "";
                    subregion.Text = "";
                    populationTextbox.Text = "";

                    listViewCur.Items.Clear();
                    listViewLang.Items.Clear();
                }
            }
        }


        // OpenButton_Click is for a file "navigator box" or OpenFileDialog 
        // starts with a new instantiation of OpenFileDialog, sets the InitialDirectory to the working
        // sets the filter to only see json files
        // then sets the title to "Open Countries From JSON"
        // checks to see if filename is not null then attempts to desearlize within a try catch
        // little bit bad practice the try catch has a catch all Exception rather than the specific one
        // thrown for an incorrect file 

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "JSON files (*.json) | *.json";
            openFileDialog.Title = "Open Countries From JSON";

            if(openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                if(fileName != null || fileName != "")
                {
                    countryList.Clear();
                    DeserJSON desrJ = new DeserJSON();


                    // catches serilization error 
                    try {
                        countryList = desrJ.serDataAndReturn(fileName, countryList);
                    } catch (Exception ex) { ex.ToString(); }
                    
                    filenameTextbox.Text = fileName;



                }

            }
        }

        #endregion end of event methods 
    }
}
