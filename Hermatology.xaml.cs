using PatientManagementSystem.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using PatientManagementSystem.Databases;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Media;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics;

namespace PatientManagementSystem
{

    public class IHematologyUrinalysis
    {

        public int Id { get; set; }
        public int PatientId { get; set; }
        public string ReferenceNumber { get; set; }
        public string HGB { get; set; }
        public string HCT { get; set; }
        public string RBC { get; set; }
        public string WBC { get; set; }
        public string ESR { get; set; }
        public string Platelet { get; set; }
        public string BloodType { get; set; }
        public string Segmenters { get; set; }
        public string Lymphocytes { get; set; }
        public string Monocytes { get; set; }
        public string Eosinophils { get; set; }
        public string Basophils { get; set; }
        public string Bands { get; set; }
        public string Color { get; set; }
        public string Transparency { get; set; }
        public string React { get; set; }
        public string SpecificGravity { get; set; }
        public string Sugar { get; set; }
        public string Albumin { get; set; }
        public string PregnancyTest { get; set; }
        public string Method { get; set; }
        public string EpithelialCell { get; set; }
        public string PusCell { get; set; }
        public string RedCell { get; set; }
        public string AmorphousSubs { get; set; }
        public string MucousThreads { get; set; }
        public string Bacteria { get; set; }
        public string Others { get; set; }
        public string Crystals { get; set; }
        public string Parasites { get; set; }
        public string MedicalTechnologistName { get; set; }
        public string PathologistName { get; set; }

    }

    public partial class Hermatology : UserControl
    {

        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        public Hermatology()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            GetAllData();
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Open the database connection.
                _dbManager.OpenConnection();

                // Create a new command object.
                SQLiteCommand command = _dbManager.CreateCommand();

                string query = "INSERT INTO tbl_hematologyUrinalysis (patientId, referenceNumber, hgb,hct, rbc, wbc, esr, platelet, bloodType, segmenters, lymphocytes, monocytes, eosinophils, basophils, bands, color, transparency, react, specificGravity, sugar, albumin, pregnancyTest, method, epithelialCell, pusCell, redCell, amorphousSubs, mucousThreads, bacteria, others, crystals, parasites, medicalTechnologistName, pathologistName) VALUES (@PatientId, @ReferenceNumber, @HGB, @HCT, @RBC, @WBC, @ESR, @PLATELET, @BLOODTYPE, @SEGMENTERS, @LYMPHOCYTES, @MONOCYTES, @EOSINOPHILS, @BASOPHILS, @BANDS, @COLOR, @TRANSPARENCY, @REACT, @SPECIFICGRAVITY, @SUGAR, @ALBUMIN, @PREGNANCYTEST, @METHOD, @EPITHELIALCELL, @PUSCELL, @REDCELL, @AMORPHOUSSUBS, @MUCOUSTHREADS, @BACTERIA, @OTHERS, @CRYSTALS, @PARASITES, @MEDICALTECHNOLOGISTNAME, @PATHOLOGISTNAME)";

                //string query = "INSERT INTO tbl_hematologyUrinalysis (patientId, referenceNumber, hgb,hct, rbc, wbc, esr, platelet, bloodType, segmenters, lymphocytes, monocytes, eosinophils, basophils, bands, color, transparency, react, specificGravity) VALUES (@PatientId, @ReferenceNumber, @HGB, @HCT, @RBC, @WBC, @ESR, @PLATELET, @BLOODTYPE, @SEGMENTERS, @LYMPHOCYTES, @MONOCYTES, @EOSINOPHILS, @BASOPHILS, @BANDS, @COLOR, @TRANSPARENCY, @REACT, @SPECIFICGRAVITY)";

                // Add the parameter values, ensuring that numeric values are converted to strings
                command.CommandText = query;
                command.Parameters.AddWithValue("@PatientId", int.Parse(txtPatientId.Text));
                command.Parameters.AddWithValue("@ReferenceNumber", txtReferenceNumber.Text);
                command.Parameters.AddWithValue("@HGB", txtHgb.Text);
                command.Parameters.AddWithValue("@HCT", txtHct.Text);
                command.Parameters.AddWithValue("@RBC", txtRbc.Text);
                command.Parameters.AddWithValue("@WBC", txtWbc.Text);
                command.Parameters.AddWithValue("@ESR", txtEsr.Text);
                command.Parameters.AddWithValue("@PLATELET", txtPlatelet.Text);
                command.Parameters.AddWithValue("@BLOODTYPE", txtBloodType.Text);
                command.Parameters.AddWithValue("@SEGMENTERS", txtSegmenters.Text);
                command.Parameters.AddWithValue("@LYMPHOCYTES", txtLymphocytes.Text);
                command.Parameters.AddWithValue("@MONOCYTES", txtMonocytes.Text);
                command.Parameters.AddWithValue("@EOSINOPHILS", txtEosinophils.Text);
                command.Parameters.AddWithValue("@BASOPHILS", txtBasophils.Text);
                command.Parameters.AddWithValue("@BANDS", txtBands.Text);
                command.Parameters.AddWithValue("@COLOR", txtColor.Text);
                command.Parameters.AddWithValue("@TRANSPARENCY", txtTransparency.Text);
                command.Parameters.AddWithValue("@REACT", txtReact.Text);
                command.Parameters.AddWithValue("@SPECIFICGRAVITY", txtSpecificGravity.Text);
                command.Parameters.AddWithValue("@SUGAR", txtSugar.Text);
                command.Parameters.AddWithValue("@ALBUMIN", txtAlbumin.Text);
                command.Parameters.AddWithValue("@PREGNANCYTEST", txtPregnancyTest.Text);
                command.Parameters.AddWithValue("@METHOD", txtMethod.Text);
                command.Parameters.AddWithValue("@EPITHELIALCELL", txtEpithelialCell.Text);
                command.Parameters.AddWithValue("@PUSCELL", txtPusCell.Text);
                command.Parameters.AddWithValue("@REDCELL", txtRedCell.Text);
                command.Parameters.AddWithValue("@AMORPHOUSSUBS", txtAmpSubs.Text);
                command.Parameters.AddWithValue("@MUCOUSTHREADS", txtMCThreads.Text);
                command.Parameters.AddWithValue("@BACTERIA", txtBacteria.Text);
                command.Parameters.AddWithValue("@OTHERS", txtOthers.Text);
                command.Parameters.AddWithValue("@CRYSTALS", txtCrystals.Text);
                command.Parameters.AddWithValue("@PARASITES", txtParasites.Text);
                command.Parameters.AddWithValue("@MEDICALTECHNOLOGISTNAME", txtMTechName.Text);
                command.Parameters.AddWithValue("@PATHOLOGISTNAME", txtPathologistName.Text);


                Debug.WriteLine(command.CommandText);
                // Execute the query.
                int rowsAffected = command.ExecuteNonQuery();

                // Close the database connection.
                _dbManager.CloseConnection();

                // Check if the query was successful.
                if (rowsAffected > 0)
                {
                    // The query was successful.
                    MessageBox.Show("Added successfully.");

                }
                else
                {
                    // The query was not successful.
                    MessageBox.Show("Error: Could not be added.");
                }
                GetAllData();
                ShowMainWindow();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("REFRESH");
            GetAllData();
        }

        public void GetAllData()
        {


            try
            {
                // Create a list to store user data.
                List<IHematologyUrinalysis> Data = new List<IHematologyUrinalysis>();
                _dbManager.OpenConnection();



                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_hematologyUrinalysis";

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Assuming the first column is the ID and the second column is the Name.
                                Debug.WriteLine("TEST");
                                int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);  // Handle NULL value for integer
                                int patientId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);  // Handle NULL value for integer
                                string referenceNumber = reader.IsDBNull(2) ? null : reader.GetString(2);  // Handle NULL value for string
                                string hgb = reader.IsDBNull(3) ? null : reader.GetString(3);
                                string hct = reader.IsDBNull(4) ? null : reader.GetString(4);
                                string rbc = reader.IsDBNull(5) ? null : reader.GetString(5);
                                string wbc = reader.IsDBNull(6) ? null : reader.GetString(6);
                                string esr = reader.IsDBNull(7) ? null : reader.GetString(7);
                                string platelet = reader.IsDBNull(8) ? null : reader.GetString(8);
                                string bloodType = reader.IsDBNull(9) ? null : reader.GetString(9);
                                string segmenters = reader.IsDBNull(10) ? null : reader.GetString(10);
                                string lymphocytes = reader.IsDBNull(11) ? null : reader.GetString(11);
                                string monocytes = reader.IsDBNull(12) ? null : reader.GetString(12);
                                string eosinophils = reader.IsDBNull(13) ? null : reader.GetString(13);
                                string basophils = reader.IsDBNull(14) ? null : reader.GetString(14);
                                string bands = reader.IsDBNull(15) ? null : reader.GetString(15);
                                string color = reader.IsDBNull(16) ? null : reader.GetString(16);
                                string transparency = reader.IsDBNull(17) ? null : reader.GetString(17);
                                string react = reader.IsDBNull(18) ? null : reader.GetString(18);
                                string specificGravity = reader.IsDBNull(19) ? null : reader.GetString(19);
                                string sugar = reader.IsDBNull(20) ? null : reader.GetString(20);
                                string albumin = reader.IsDBNull(21) ? null : reader.GetString(21);
                                string pregnancyTest = reader.IsDBNull(22) ? null : reader.GetString(22);
                                string method = reader.IsDBNull(23) ? null : reader.GetString(23);
                                string epithelialCell = reader.IsDBNull(24) ? null : reader.GetString(24);
                                string pusCell = reader.IsDBNull(25) ? null : reader.GetString(25);
                                string redCell = reader.IsDBNull(26) ? null : reader.GetString(26);
                                string amorphousSubs = reader.IsDBNull(27) ? null : reader.GetString(27);
                                string mucousThreads = reader.IsDBNull(28) ? null : reader.GetString(28);
                                string bacteria = reader.IsDBNull(29) ? null : reader.GetString(29);
                                string others = reader.IsDBNull(30) ? null : reader.GetString(30);
                                string crystals = reader.IsDBNull(31) ? null : reader.GetString(31);
                                string parasites = reader.IsDBNull(32) ? null : reader.GetString(32);
                                string medicalTechnologistName = reader.IsDBNull(33) ? null : reader.GetString(33);
                                string pathologistName = reader.IsDBNull(34) ? null : reader.GetString(34);

                                // Add the user to the list.
                                Data.Add(new IHematologyUrinalysis
                                {
                                    Id = id,
                                    PatientId = patientId,
                                    ReferenceNumber = referenceNumber,
                                    HGB = hgb,
                                    HCT = hct,
                                    RBC = rbc,
                                    WBC = wbc,
                                    ESR = esr,
                                    Platelet = platelet,
                                    BloodType = bloodType,
                                    Segmenters = segmenters,
                                    Lymphocytes = lymphocytes,
                                    Monocytes = monocytes,
                                    Eosinophils = eosinophils,
                                    Basophils = basophils,
                                    Bands = bands,
                                    Color = color,
                                    Transparency = transparency,
                                    React = react,
                                    SpecificGravity = specificGravity,
                                    Sugar = sugar,
                                    Albumin = albumin,
                                    PregnancyTest = pregnancyTest,
                                    Method = method,
                                    EpithelialCell = epithelialCell,
                                    PusCell = pusCell,
                                    RedCell = redCell,
                                    AmorphousSubs = amorphousSubs,
                                    MucousThreads = mucousThreads,
                                    Bacteria = bacteria,
                                    Others = others,
                                    Crystals = crystals,
                                    Parasites = parasites,
                                    MedicalTechnologistName = medicalTechnologistName,
                                    PathologistName = pathologistName,
                                });
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                        }

                    }


                }

                // Serialize the 'users' list to JSON.
                //string json = JsonConvert.SerializeObject(Data);

                // Now 'json' contains the JSON representation of your data.
                //Console.WriteLine(json);
                dataGrid.ItemsSource = Data;
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                MessageBox.Show($"Error in getting data: {ex.Message}");
            }
            finally
            {
                _dbManager.CloseConnection();
            }
        }


        private void ShowAddWindow_Click(object sender, RoutedEventArgs e)
        {
            gridSideBar.Visibility = Visibility.Collapsed;
            gridDataTable.Visibility = Visibility.Collapsed;
            gridAddData.Visibility = Visibility.Visible; 
        }

   

        private void ShowMainWindow()
        {
            gridSideBar.Visibility = Visibility.Visible;
            gridDataTable.Visibility = Visibility.Visible;
            gridAddData.Visibility = Visibility.Collapsed;
        }

        private void ShowWindow_Click(object sender, RoutedEventArgs e)
        {
            ShowMainWindow();
        }


        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // When the Enter key is pressed in the searchTextBox, perform the search.
                PerformSearch();
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            // When the Search button is clicked, perform the search.
            PerformSearch();
        }

        private void PerformSearch()
        {
            // Get the search keyword from the TextBox.
            string searchKeyword = searchTextBox.Text;

            // Call the SearchPatients method with the search keyword.
            SearchData(searchKeyword);
        }

        public void SearchData(string searchKeyword)
        {
            try
            {
                // Create a list to store patient data matching the search keyword.
                List<IHematologyUrinalysis> matchingData = new List<IHematologyUrinalysis>();
                _dbManager.OpenConnection();

                // Perform a database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_hematologyUrinalysis WHERE " +
                        "id LIKE @SearchKeyword OR " +
                        "patientId LIKE @SearchKeyword OR " +
                        "referenceNumber LIKE @SearchKeyword OR " +
                        "hgb LIKE @SearchKeyword OR " +
                        "hct LIKE @SearchKeyword OR " +
                        "rbc LIKE @SearchKeyword OR " +
                        "wbc LIKE @SearchKeyword OR " +
                        "esr LIKE @SearchKeyword OR " +
                        "platelet LIKE @SearchKeyword OR " +
                        "bloodType LIKE @SearchKeyword OR " +
                        "segmenters LIKE @SearchKeyword OR " +
                        "lymphocytes LIKE @SearchKeyword OR " +
                        "monocytes LIKE @SearchKeyword OR " +
                        "eosinophils LIKE @SearchKeyword OR " +
                        "basophils LIKE @SearchKeyword OR " +

                        "bands LIKE @SearchKeyword OR " +
                        "color LIKE @SearchKeyword OR " +
                        "transparency LIKE @SearchKeyword OR " +
                        "react LIKE @SearchKeyword OR " +
                        "specificGravity LIKE @SearchKeyword OR " +
                        "sugar LIKE @SearchKeyword OR " +
                        "albumin LIKE @SearchKeyword OR " +
                        "pregnancyTest LIKE @SearchKeyword OR " +
                        "method LIKE @SearchKeyword OR " +
                        "epithelialCell LIKE @SearchKeyword OR " +
                        "pusCell LIKE @SearchKeyword OR " +

                        "redCell LIKE @SearchKeyword OR " +
                        "amorphousSubs LIKE @SearchKeyword OR " +
                        "mucousThreads LIKE @SearchKeyword OR " +
                        "bacteria LIKE @SearchKeyword OR " +
                        "others LIKE @SearchKeyword OR " +
                        "crystals LIKE @SearchKeyword OR " +
                        "parasites LIKE @SearchKeyword OR " +
                            
                        "medicalTechnologistName LIKE @SearchKeyword OR " +

                        "pathologistName LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while (reader.Read())
                        {
                            int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);  // Handle NULL value for integer
                            int patientId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);  // Handle NULL value for integer
                            string referenceNumber = reader.IsDBNull(2) ? null : reader.GetString(2);  // Handle NULL value for string
                            string hgb = reader.IsDBNull(3) ? null : reader.GetString(3);
                            string hct = reader.IsDBNull(4) ? null : reader.GetString(4);
                            string rbc = reader.IsDBNull(5) ? null : reader.GetString(5);
                            string wbc = reader.IsDBNull(6) ? null : reader.GetString(6);
                            string esr = reader.IsDBNull(7) ? null : reader.GetString(7);
                            string platelet = reader.IsDBNull(8) ? null : reader.GetString(8);
                            string bloodType = reader.IsDBNull(9) ? null : reader.GetString(9);
                            string segmenters = reader.IsDBNull(10) ? null : reader.GetString(10);
                            string lymphocytes = reader.IsDBNull(11) ? null : reader.GetString(11);
                            string monocytes = reader.IsDBNull(12) ? null : reader.GetString(12);
                            string eosinophils = reader.IsDBNull(13) ? null : reader.GetString(13);
                            string basophils = reader.IsDBNull(14) ? null : reader.GetString(14);
                            string bands = reader.IsDBNull(15) ? null : reader.GetString(15);
                            string color = reader.IsDBNull(16) ? null : reader.GetString(16);
                            string transparency = reader.IsDBNull(17) ? null : reader.GetString(17);
                            string react = reader.IsDBNull(18) ? null : reader.GetString(18);
                            string specificGravity = reader.IsDBNull(19) ? null : reader.GetString(19);
                            string sugar = reader.IsDBNull(20) ? null : reader.GetString(20);
                            string albumin = reader.IsDBNull(21) ? null : reader.GetString(21);
                            string pregnancyTest = reader.IsDBNull(22) ? null : reader.GetString(22);
                            string method = reader.IsDBNull(23) ? null : reader.GetString(23);
                            string epithelialCell = reader.IsDBNull(24) ? null : reader.GetString(24);
                            string pusCell = reader.IsDBNull(25) ? null : reader.GetString(25);
                            string redCell = reader.IsDBNull(26) ? null : reader.GetString(26);
                            string amorphousSubs = reader.IsDBNull(27) ? null : reader.GetString(27);
                            string mucousThreads = reader.IsDBNull(28) ? null : reader.GetString(28);
                            string bacteria = reader.IsDBNull(29) ? null : reader.GetString(29);
                            string others = reader.IsDBNull(30) ? null : reader.GetString(30);
                            string crystals = reader.IsDBNull(31) ? null : reader.GetString(31);
                            string parasites = reader.IsDBNull(32) ? null : reader.GetString(32);
                            string medicalTechnologistName = reader.IsDBNull(33) ? null : reader.GetString(33);
                            string pathologistName = reader.IsDBNull(34) ? null : reader.GetString(34);

                            // Add the user to the list.
                            matchingData.Add(new IHematologyUrinalysis
                            {
                                Id = id,
                                PatientId = patientId,
                                ReferenceNumber = referenceNumber,
                                HGB = hgb,
                                HCT = hct,
                                RBC = rbc,
                                WBC = wbc,
                                ESR = esr,
                                Platelet = platelet,
                                BloodType = bloodType,
                                Segmenters = segmenters,
                                Lymphocytes = lymphocytes,
                                Monocytes = monocytes,
                                Eosinophils = eosinophils,
                                Basophils = basophils,
                                Bands = bands,
                                Color = color,
                                Transparency = transparency,
                                React = react,
                                SpecificGravity = specificGravity,
                                Sugar = sugar,
                                Albumin = albumin,
                                PregnancyTest = pregnancyTest,
                                Method = method,
                                EpithelialCell = epithelialCell,
                                PusCell = pusCell,
                                RedCell = redCell,
                                AmorphousSubs = amorphousSubs,
                                MucousThreads = mucousThreads,
                                Bacteria = bacteria,
                                Others = others,
                                Crystals = crystals,
                                Parasites = parasites,
                                MedicalTechnologistName = medicalTechnologistName,
                                PathologistName = pathologistName,


                            });

                        }
                    }
                }

                dataGrid.ItemsSource = matchingData;
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                MessageBox.Show($"Error in searching patients: {ex.Message}");
            }
            finally
            {
                _dbManager.CloseConnection();
            }
        }

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToPatient();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUsers();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToLabTest();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToDrugTest();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToHematology();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToRadiographic();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToFecalysis();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToUserSettings();
        }

    }
}
