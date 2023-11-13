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
    /// Interaction logic for Users.xaml
    /// </summary>
    /// 
    public class IUsers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string Role { get; set; }
        public string DateCreated { get; set; }
    }

    public partial class Users : UserControl
    {
        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

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
                List<IUsers> Data = new List<IUsers>();
                _dbManager.OpenConnection();



                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT id, firstname, lastname, email, role, date_created FROM tbl_users";

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                                int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);

                                string firstname = reader.IsDBNull(1) ? null : reader.GetString(1);
                                string lastname = reader.IsDBNull(2) ? null : reader.GetString(2);
                                string email = reader.IsDBNull(3) ? null : reader.GetString(3);
                                string role = reader.IsDBNull(4) ? null : reader.GetString(4);

                                string dateCreated = reader.IsDBNull(5) ? null : reader.GetString(5);


                                // Add the user to the list.
                                Data.Add(new IUsers
                                {
                                    Id = id,
                                    FirstName = firstname,
                                    LastName = lastname,
                                    Email = email,
                                    Role = role,
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


        public Users()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            GetAllData();
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
                List<IUsers> matchingData = new List<IUsers>();
                _dbManager.OpenConnection();

                // Perform a database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_radiographic WHERE " +
                        "id LIKE @SearchKeyword OR " +
                        "firstname LIKE @SearchKeyword OR " +
                        "lastname LIKE @SearchKeyword OR " +
                        "email LIKE @SearchKeyword OR " +
                        "role LIKE @SearchKeyword OR " +
                        "date_created LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while (reader.Read())
                        {


                            int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);

                            string firstname = reader.IsDBNull(1) ? null : reader.GetString(1);
                            string lastname = reader.IsDBNull(2) ? null : reader.GetString(2);
                            string email = reader.IsDBNull(3) ? null : reader.GetString(3);
                            string role = reader.IsDBNull(4) ? null : reader.GetString(4);

                            string dateCreated = reader.IsDBNull(5) ? null : reader.GetString(5);


                            // Add the user to the list.
                            matchingData.Add(new IUsers
                            {
                                Id = id,
                                FirstName = firstname,
                                LastName = lastname,
                                Email = email,
                                Role = role,
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
