using PatientManagementSystem.Databases;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Media;

namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for LaboratoryTest.xaml
    /// </summary>
    /// 

    public class ILaboratoryTest
    {

        public int Id { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; }
        public string ReferenceRange { get; set; }
        public int EmployeeAssignedId { get; set; }
        public string LabLocation { get; set; }
        public int PatientId { get; set; }
        public string TestDate { get; set; }

    }
    public partial class LaboratoryTest : UserControl
    {
        private DatabaseManager _dbManager;

        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;


        public LaboratoryTest()
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
                List<ILaboratoryTest> labTest = new List<ILaboratoryTest>();
                _dbManager.OpenConnection();



                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_laboratoryTest";

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while (reader.Read())
                        {
                            // Assuming the first column is the ID and the second column is the Name.
                            int id = reader.GetInt32(0);
                            string testName = reader.GetString(1);
                            string testDate = reader.GetString(2);
                            string testResult = reader.GetString(3);
                            string referenceRange = reader.GetString(4);
                            int employeeAssignedId = reader.GetInt32(5);
                            int patientId = reader.GetInt32(6);
                            string labLocation = reader.GetString(7);


                            // Add the user to the list.
                            labTest.Add(new ILaboratoryTest { Id = id, TestName = testName, TestResult = testResult, ReferenceRange = referenceRange, EmployeeAssignedId = employeeAssignedId, LabLocation = labLocation, TestDate = testDate, PatientId = patientId });

                        }
                    }


                }

                // Serialize the 'users' list to JSON.
                //string json = JsonConvert.SerializeObject(patients);

                // Now 'json' contains the JSON representation of your data.
                //MessageBox.Show(json);
                dataGrid.ItemsSource = labTest;
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
                string query = "INSERT INTO tbl_laboratoryTest (testName, testResult, referenceRange, employeeAssignedid, patientId, labLocation) VALUES (@TestName, @TestResult, @ReferenceRange, @EmployeeAssignedId, @PatientId, @LabLocation)";

                // Add the parameter values.
                command.CommandText = query;
                //command.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                command.Parameters.AddWithValue("@TestName", txtTestName.Text);
                command.Parameters.AddWithValue("@TestResult", txtTestResult.Text);
                command.Parameters.AddWithValue("@ReferenceRange", txtReferenceRange.Text);
                command.Parameters.AddWithValue("@EmployeeAssignedId", int.Parse(txtEmployeeId.Text));
                command.Parameters.AddWithValue("@PatientId", int.Parse(txtPatientId.Text));
                command.Parameters.AddWithValue("@LabLocation", txtLabLocation.Text);

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
                List<ILaboratoryTest> matchingData = new List<ILaboratoryTest>();
                _dbManager.OpenConnection();

                // Perform a database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_patients WHERE " +
                        "testName LIKE @SearchKeyword OR " +
                        "testDate LIKE @SearchKeyword OR " +
                        "testResult LIKE @SearchKeyword OR " +
                        "referenceRange LIKE @SearchKeyword OR " +
                        "employeeAssignedId LIKE @SearchKeyword OR " +
                        "patientId LIKE @SearchKeyword OR " +
                        "labLocation LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string testName = reader.GetString(1);
                            string testDate = reader.GetString(2);
                            string testResult = reader.GetString(3);
                            string referenceRange = reader.GetString(4);
                            int employeeAssignedId = reader.GetInt32(5);
                            int patientId = reader.GetInt32(6);
                            string labLocation = reader.GetString(7);


                            // Add the user to the list.
                            matchingData.Add(new ILaboratoryTest { Id = id, TestName = testName, TestResult = testResult, ReferenceRange = referenceRange, EmployeeAssignedId = employeeAssignedId, LabLocation = labLocation, TestDate = testDate, PatientId = patientId });
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
