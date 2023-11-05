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
    public class IDrugTest
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string ReferenceNumber { get; set; }
        public string TestMethod { get; set; }
        public string Purpose { get; set; }
        public string RequestingParties { get; set; }
        public string Analyst { get; set; }
        public string HeadOfLaboratory { get; set; }
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


                                int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);

                                int patientId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                                string referenceNumber = reader.IsDBNull(2) ? null : reader.GetString(2);

                                string testMethod = reader.IsDBNull(3) ? null : reader.GetString(3);

                                string purpose = reader.IsDBNull(4) ? null : reader.GetString(4);
                                string requestingParties = reader.IsDBNull(5) ? null : reader.GetString(5);
                                string analyst = reader.IsDBNull(6) ? null : reader.GetString(6);
                                string headOfLaboratory = reader.IsDBNull(7) ? null : reader.GetString(7);

                                // Add the user to the list.
                                Data.Add(new IDrugTest
                                {
                                    Id = id,
                                    PatientId = patientId,
                                    ReferenceNumber = referenceNumber,
                                    TestMethod = testMethod,
                                    Purpose = purpose,
                                    RequestingParties = requestingParties,
                                    Analyst = analyst,
                                    HeadOfLaboratory = headOfLaboratory

                                });
                            }
                        }
                        else
                        {
                           
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
                    command.CommandText = "SELECT * FROM tbl_radiographic WHERE " +
                        "id LIKE @SearchKeyword OR " +
                        "patientId LIKE @SearchKeyword OR " +
                        "referenceNumber LIKE @SearchKeyword OR " +
                        "testMethod LIKE @SearchKeyword OR " +
                        "purpose LIKE @SearchKeyword OR " +


                        "requestingParties LIKE @SearchKeyword OR " +
                        "analyst LIKE @SearchKeyword OR " +


                        "headOfLaboratory LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while (reader.Read())
                        {


                            int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);

                            int patientId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                            string referenceNumber = reader.IsDBNull(2) ? null : reader.GetString(2);

                            string testMethod = reader.IsDBNull(3) ? null : reader.GetString(3);

                            string purpose = reader.IsDBNull(4) ? null : reader.GetString(4);
                            string requestingParties = reader.IsDBNull(5) ? null : reader.GetString(5);
                            string analyst = reader.IsDBNull(6) ? null : reader.GetString(6);
                            string headOfLaboratory = reader.IsDBNull(7) ? null : reader.GetString(7);

                            // Add the user to the list.
                            matchingData.Add(new IDrugTest
                            {
                                Id = id,
                                PatientId = patientId,
                                ReferenceNumber = referenceNumber,
                                TestMethod = testMethod,
                                Purpose = purpose,
                                RequestingParties = requestingParties,
                                Analyst = analyst,
                                HeadOfLaboratory = headOfLaboratory

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

    }
}
