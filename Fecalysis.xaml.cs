using PatientManagementSystem.Databases;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Media;
using System.Windows.Media;

namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for Fecalysis.xaml
    /// </summary>
    /// 
    public class IFecalysis
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Color { get; set; }
        public string OccultBlood { get; set; }
        public string PusCells { get; set; }
        public string RedBloodCeels { get; set; }
        public string Cyst { get; set; }
        public string Trophozolte { get; set; }
        public string IntestinalParasites { get; set; }

        public string Consistency { get; set; }

        public string Pathologist { get; set; }

        public string MedicalTechnologist { get; set; }

        public string DateCreated { get; set; }

    }
    public partial class Fecalysis : UserControl
    {
        private DatabaseManager _dbManager;

        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        public Fecalysis()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager();
            GetAllData();
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
                List<IFecalysis> dataFromDb = new List<IFecalysis>();
                _dbManager.OpenConnection();



                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_fecalysis";

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while (reader.Read())
                        {
                            // Assuming the first column is the ID and the second column is the Name.
                            int id = reader.GetInt32(0);
                            int patientId = reader.GetInt32(1);
                            string color = reader.GetString(2);
                            string occultBlood = reader.GetString(3);
                            string pusCells = reader.GetString(4);
                            string redBloodCells = reader.GetString(5);
                            string cyst = reader.GetString(6);
                            string trophozolte = reader.GetString(7);
                            string intestinalParasite = reader.GetString(8);
                            string consistency = reader.GetString(9);
                            string pathologist = reader.GetString(10);
                            string medicalTechnologist = reader.GetString(11);
                            string dateCreated = reader.GetString(12);


                            // Add the user to the list.
                            dataFromDb.Add(new IFecalysis { Id = id, PatientId = patientId, Color = color, OccultBlood = occultBlood, PusCells = pusCells, RedBloodCeels = redBloodCells, Cyst = cyst, Trophozolte = trophozolte, IntestinalParasites = intestinalParasite, Consistency = consistency, Pathologist = pathologist, MedicalTechnologist = medicalTechnologist, DateCreated = dateCreated});

                        }
                    }


                }

                // Serialize the 'users' list to JSON.
                //string json = JsonConvert.SerializeObject(patients);

                // Now 'json' contains the JSON representation of your data.
                //MessageBox.Show(json);
                dataGrid.ItemsSource = dataFromDb;
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


        private void AddData_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Open the database connection.
                _dbManager.OpenConnection();

                // Create a new command object.
                SQLiteCommand command = _dbManager.CreateCommand();

                // Create the insert query.
                string query = "INSERT INTO tbl_fecalysis (patientId, color, occultBlood, pusCells, redBloodCells, cyst, trophozolte, intestinalParasite, consistency, pathologist, medicalTechnologist) VALUES (@PatientId, @Color, @OccultBlood, @PusCells, @RedBloodCells, @Cyst, @Trophozolte, @IntestinalParasite, @Consistency, @Pathologist, @MedicalTechnologist)";

                // Add the parameter values.
                command.CommandText = query;
                //command.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                command.Parameters.AddWithValue("@PatientId", int.Parse(txtPatientId.Text));
                command.Parameters.AddWithValue("@Color", txtColor.Text);
                command.Parameters.AddWithValue("@OccultBlood", txtOccultBlood.Text);
                command.Parameters.AddWithValue("@PusCells", txtPusCells.Text);
                command.Parameters.AddWithValue("@RedBloodCells", txtRedBloodCells.Text);
                command.Parameters.AddWithValue("@Cyst", txtCyst.Text);
                command.Parameters.AddWithValue("@Trophozolte", txtPathologist.Text);
                command.Parameters.AddWithValue("@IntestinalParasite", txtIntestinalParasite.Text);
                command.Parameters.AddWithValue("@Consistency" , txtConsistency.Text);
                command.Parameters.AddWithValue("@Pathologist", txtPathologist.Text);
                command.Parameters.AddWithValue("@MedicalTechnologist", txtMedicalTechnologist.Text);

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
                MessageBox.Show("Error: ", ex.Message);
            }

        }


        private void ShowWindow_Click(object sender, RoutedEventArgs e)
        {
            ShowMainWindow();
        }

        private void ShowMainWindow()
        {
            gridSideBar.Visibility = Visibility.Visible;
            gridAddData.Visibility = Visibility.Collapsed;
            gridDataTable.Visibility = Visibility.Visible;
        }

        private void ShowAddWindow()
        {

            gridSideBar.Visibility = Visibility.Collapsed;
            gridDataTable.Visibility = Visibility.Collapsed;
            gridAddData.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowAddWindow();
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
                List<IFecalysis> matchingData = new List<IFecalysis>();
                _dbManager.OpenConnection();

                // Perform a database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_fecalysis WHERE " +
                        "patiendId LIKE @SearchKeyword OR " +
                        "color LIKE @SearchKeyword OR " +
                        "occultBlood LIKE @SearchKeyword OR " +
                        "pusCells LIKE @SearchKeyword OR "+
                        "redBloodCells LIKE @SearchKeyword OR " +
                        "cyst LIKE @SearchKeyword OR " +
                        "trophozolte LIKE @SearchKeyword OR " +
                        "intestinalParasite LIKE @SearchKeyword OR " +
                        "consistency LIKE @SearchKeyword OR " +
                        "pathologist LIKE @SearchKeyword OR " +
                        "medicalTechnologist LIKE @SearchKeyword OR " +
                        "labLocation LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the first column is the ID and the second column is the Name.
                            int id = reader.GetInt32(0);
                            int patientId = reader.GetInt32(1);
                            string color = reader.GetString(2);
                            string occultBlood = reader.GetString(3);
                            string pusCells = reader.GetString(4);
                            string redBloodCells = reader.GetString(5);
                            string cyst = reader.GetString(6);
                            string trophozolte = reader.GetString(7);
                            string intestinalParasite = reader.GetString(8);
                            string consistency = reader.GetString(9);
                            string pathologist = reader.GetString(10);
                            string medicalTechnologist = reader.GetString(11);
                            string dateCreated = reader.GetString(12);


                            // Add the user to the list.
                            matchingData.Add(new IFecalysis { Id = id, PatientId = patientId, Color = color, OccultBlood = occultBlood, PusCells = pusCells, RedBloodCeels = redBloodCells, Cyst = cyst, Trophozolte = trophozolte, IntestinalParasites = intestinalParasite, Consistency = consistency, Pathologist = pathologist, MedicalTechnologist = medicalTechnologist, DateCreated = dateCreated });

                        }
                    }
                }

                dataGrid.ItemsSource = matchingData;
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                MessageBox.Show($"Error in searching data: {ex.Message}");
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
