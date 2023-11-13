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
    /// <summary>
    /// Interaction logic for Radiographic.xaml
    /// </summary>
    /// 
    public class IRadiographic
    {
        public int Id { get; set; }
        public string Impression { get; set; }
        public string Interpretation { get; set; }
        public int PatientId { get; set; }
        public string ReferenceNo { get; set; }
        public string TypeOfExam { get; set; }
        public string DateCreated { get; set; }

    }
    public partial class Radiographic : UserControl
    {
        public Radiographic()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            GetAllData();
        }

        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;



        private void AddData_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Open the database connection.
                _dbManager.OpenConnection();

                // Create a new command object.
                SQLiteCommand command = _dbManager.CreateCommand();

                string query = "INSERT INTO tbl_radiographic (impression, interpretation, patientId, referenceNo, typeOfExam) VALUES (@IMPRESSION, @INTERPRETATION, @PATIENTID, @REFERENCENO, @TYPEOFEXAM)";

           

                // Add the parameter values, ensuring that numeric values are converted to strings
                command.CommandText = query;
                command.Parameters.AddWithValue("@IMPRESSION", txtImpression.Text);
                command.Parameters.AddWithValue("@INTERPRETATION", txtInterpretation.Text);
                command.Parameters.AddWithValue("@PATIENTID", int.Parse(txtPatientId.Text));
                command.Parameters.AddWithValue("@REFERENCENO", txtReferenceNo.Text);
                command.Parameters.AddWithValue("@TYPEOFEXAM", txtTypeOfExam.Text);




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
                List<IRadiographic> Data = new List<IRadiographic>();
                _dbManager.OpenConnection();



                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_radiographic";

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                             
                             
                                int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);  
                             
                                string impression = reader.IsDBNull(1) ? null : reader.GetString(1);
                                
                                string interpretation = reader.IsDBNull(2) ? null : reader.GetString(2);
                                
                                int patientId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                                string referenceNo = reader.IsDBNull(4) ? null : reader.GetString(4);

                                string typeOfExam = reader.IsDBNull(5) ? null : reader.GetString(5);

                                string dateCreated = reader.IsDBNull(6) ? null : reader.GetString(6);
                        

                                // Add the user to the list.
                                Data.Add(new IRadiographic
                                {
                                    Id = id,
                                    Impression = impression,
                                    Interpretation = interpretation,
                                    PatientId = patientId,
                                    ReferenceNo = referenceNo,
                                    TypeOfExam = typeOfExam,
                                    DateCreated = dateCreated

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
                List<IRadiographic> matchingData = new List<IRadiographic>();
                _dbManager.OpenConnection();

                // Perform a database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_radiographic WHERE " +
                        "id LIKE @SearchKeyword OR " +
                        "impression LIKE @SearchKeyword OR " +
                        "interpretation LIKE @SearchKeyword OR " +
                        "patientId LIKE @SearchKeyword OR " +
                        "referenceNo LIKE @SearchKeyword OR " +
                        "typeOfExam LIKE @SearchKeyword OR " +
                        "dateCreated LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while (reader.Read())
                        {
                            int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);

                            string impression = reader.IsDBNull(1) ? null : reader.GetString(1);

                            string interpretation = reader.IsDBNull(2) ? null : reader.GetString(2);

                            int patientId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                            string referenceNo = reader.IsDBNull(4) ? null : reader.GetString(4);

                            string typeOfExam = reader.IsDBNull(5) ? null : reader.GetString(5);

                            string dateCreated = reader.IsDBNull(6) ? null : reader.GetString(6);

                            // Add the user to the list.
                            matchingData.Add(new IRadiographic
                            {
                                Id = id,
                                Impression = impression,
                                Interpretation = interpretation,
                                PatientId = patientId,
                                ReferenceNo = referenceNo,
                                TypeOfExam = typeOfExam,
                                DateCreated = dateCreated

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

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.LogoutAdmin();
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
