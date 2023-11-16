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

//    Id: primary key int
//PatientId: int
//CCFNO : string
//FullName : string
//Transaction Date: CurrentDate
//ReportDate: String
//TestMethod: string
//Gender: String
//Purpose: String
//RequestingParties: String
//MethResult: String
//MethRemarks:String
//TetraResult: String
//TetraRemarks: String
//Analyst: String
//HeadOfLab: String

    public class IDrugTest
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string CCFNO { get; set; }
        public string FullName { get; set; }
        public string TransactionDate { get; set; }
        public string ReportDate { get; set; }
        public string TestMethod { get; set; }
        public string Gender { get; set; }
        public string Purpose { get; set; }
        public string RequestingParties { get; set; }
        public string MethResult { get; set; }
        public string MethRemarks { get; set; }
        public string TetraResult { get; set; }
        public string TetraRemarks { get; set; }
        public string Analyst { get; set; }
        public string HeadOfLab { get; set; }
        
    }

    public partial class DrugTest : UserControl
    {
        private DatabaseManager _dbManager;
     
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        public DrugTest()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            GetAllData();
        }

        public void GetAllData()
        {


            try
            {
                // Create a list to store user data.
                List<IDrugTest> Data = new List<IDrugTest>();
                _dbManager.OpenConnection();



                // Perform your database query using a SQLiteCommand.
                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_drugTest";

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Add the user to the list.
                                Data.Add(new IDrugTest
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                    CCFNO = reader.GetString(reader.GetOrdinal("CCFNO")),
                                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                    TransactionDate = reader.GetDateTime(reader.GetOrdinal("TransactionDate")).ToString("yyyy-MM-dd"), // Assuming TransactionDate is a DateTime field
                                    ReportDate = reader.GetString(reader.GetOrdinal("ReportDate")),
                                    TestMethod = reader.GetString(reader.GetOrdinal("TestMethod")),
                                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                    Purpose = reader.GetString(reader.GetOrdinal("Purpose")),
                                    RequestingParties = reader.GetString(reader.GetOrdinal("RequestingParties")),
                                    MethResult = reader.GetString(reader.GetOrdinal("MethResult")),
                                    MethRemarks = reader.GetString(reader.GetOrdinal("MethRemarks")),
                                    TetraResult = reader.GetString(reader.GetOrdinal("TetraResult")),
                                    TetraRemarks = reader.GetString(reader.GetOrdinal("TetraRemarks")),
                                    Analyst = reader.GetString(reader.GetOrdinal("Analyst")),
                                    HeadOfLab = reader.GetString(reader.GetOrdinal("HeadOfLab"))
                                }) ;
                            }
                        }
                        else
                        {
                            // Handle the case when there are no rows in the result.
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

        private void AddData_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Open the database connection.
                _dbManager.OpenConnection();

                // Create a new command object.
                SQLiteCommand command = _dbManager.CreateCommand();
                // Create the insert query.
                string query = "INSERT INTO tbl_drugTest (PatientId, CCFNO, FullName, TransactionDate, ReportDate, TestMethod, Gender, Purpose, RequestingParties, MethResult, MethRemarks, TetraResult, TetraRemarks, Analyst, HeadOfLab) " +
                               "VALUES (@PatientId, @CCFNO, @FullName, @TransactionDate, @ReportDate, @TestMethod, @Gender, @Purpose, @RequestingParties, @MethResult, @MethRemarks, @TetraResult, @TetraRemarks, @Analyst, @HeadOfLab)";

                // Add the parameter values.
                command.CommandText = query;
                command.Parameters.AddWithValue("@PatientId", int.Parse(txtPatientId.Text));
                command.Parameters.AddWithValue("@CCFNO", txtCCFNO.Text);
                command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                command.Parameters.AddWithValue("@TransactionDate", DateTime.Now.ToString("yyyy-MM-dd")); // Assuming TransactionDate is the current date
                command.Parameters.AddWithValue("@ReportDate", txtReportDate.Text);
                command.Parameters.AddWithValue("@TestMethod", txtTestMethod.Text);
                command.Parameters.AddWithValue("@Gender", txtGender.Text);
                command.Parameters.AddWithValue("@Purpose", txtPurpose.Text);
                command.Parameters.AddWithValue("@RequestingParties", txtRequestingParties.Text);
                command.Parameters.AddWithValue("@MethResult", txtMethResult.Text);
                command.Parameters.AddWithValue("@MethRemarks", txtMethRemarks.Text);
                command.Parameters.AddWithValue("@TetraResult", txtTetraResult.Text);
                command.Parameters.AddWithValue("@TetraRemarks", txtTetraRemarks.Text);
                command.Parameters.AddWithValue("@Analyst", txtAnalyst.Text);
                command.Parameters.AddWithValue("@HeadOfLab", txtHeadOfLab.Text);

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

        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(dataGrid, "Print DataGrid");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                List<IDrugTest> matchingData = new List<IDrugTest>();
                _dbManager.OpenConnection();

                // Perform a database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_drugTest WHERE " +
                        "id LIKE @SearchKeyword OR " +
                        "PatientId LIKE @SearchKeyword OR " +
                        "CCFNO LIKE @SearchKeyword OR " +
                        "FullName LIKE @SearchKeyword OR " +
                        "TransactionDate LIKE @SearchKeyword OR " +
                        "ReportDate LIKE @SearchKeyword OR " +
                        "TestMethod LIKE @SearchKeyword OR " +
                        "Gender LIKE @SearchKeyword OR " +
                        "Purpose LIKE @SearchKeyword OR " +
                        "RequestingParties LIKE @SearchKeyword OR " +
                        "MethResult LIKE @SearchKeyword OR " +
                        "MethRemarks LIKE @SearchKeyword OR " +
                        "TetraResult LIKE @SearchKeyword OR " +
                        "TetraRemarks LIKE @SearchKeyword OR " +
                        "Analyst LIKE @SearchKeyword OR " +
                        "HeadOfLab LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            int patientId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            string ccfNo = reader.IsDBNull(2) ? null : reader.GetString(2);
                            string fullName = reader.IsDBNull(3) ? null : reader.GetString(3);
                            string transactionDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4).ToString("yyyy-MM-dd"); // Assuming TransactionDate is a DateTime field
                            string reportDate = reader.IsDBNull(5) ? null : reader.GetString(5);
                            string testMethod = reader.IsDBNull(6) ? null : reader.GetString(6);
                            string gender = reader.IsDBNull(7) ? null : reader.GetString(7);
                            string purpose = reader.IsDBNull(8) ? null : reader.GetString(8);
                            string requestingParties = reader.IsDBNull(9) ? null : reader.GetString(9);
                            string methResult = reader.IsDBNull(10) ? null : reader.GetString(10);
                            string methRemarks = reader.IsDBNull(11) ? null : reader.GetString(11);
                            string tetraResult = reader.IsDBNull(12) ? null : reader.GetString(12);
                            string tetraRemarks = reader.IsDBNull(13) ? null : reader.GetString(13);
                            string analyst = reader.IsDBNull(14) ? null : reader.GetString(14);
                            string headOfLab = reader.IsDBNull(15) ? null : reader.GetString(15);

                            // Add the user to the list.
                            matchingData.Add(new IDrugTest
                            {
                                Id = id,
                                PatientId = patientId,
                                CCFNO = ccfNo,
                                FullName = fullName,
                                TransactionDate = transactionDate,
                                ReportDate = reportDate,
                                TestMethod = testMethod,
                                Gender = gender,
                                Purpose = purpose,
                                RequestingParties = requestingParties,
                                MethResult = methResult,
                                MethRemarks = methRemarks,
                                TetraResult = tetraResult,
                                TetraRemarks = tetraRemarks,
                                Analyst = analyst,
                                HeadOfLab = headOfLab
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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("REFRESH");
            GetAllData();
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

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.LogoutAdmin();
        }
    }
}
