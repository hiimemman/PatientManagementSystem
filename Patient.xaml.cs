using PatientManagementSystem.Databases;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Windows.Input;

namespace PatientManagementSystem
{
    public class Patients
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        //public string Status { get; set; }
        public string Address { get; set; }
    }
    public partial class Patient : UserControl
    {
        private DatabaseManager _dbManager;

        

        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        

        public Patient()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager();

            // Get all data from the database.
            GetAllPatients();

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void GetAllPatients()
        {

            
            try
            {
                // Create a list to store user data.
                List<Patients> patients = new List<Patients>();
                _dbManager.OpenConnection();

               

                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_patients";

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine(reader.ToString());
                        while (reader.Read())
                        {
                            // Assuming the first column is the ID and the second column is the Name.
                            int id = reader.GetInt32(0);
                            string firstname = reader.GetString(1);
                            string middlename = reader.GetString(2);
                            string lastname = reader.GetString(3);
                            string email = reader.GetString(4);
                            int age = reader.GetInt32(5);
                            string birthdate = reader.GetString(6);
                            string address = reader.GetString(7);

                            // Add the user to the list.
                            patients.Add(new Patients { Id = id, Firstname = firstname, Middlename = middlename, Lastname = lastname, Email = email, Age = age, BirthDate = birthdate, Address = address});

                        }
                    }


                }

                // Serialize the 'users' list to JSON.
                //string json = JsonConvert.SerializeObject(patients);

                // Now 'json' contains the JSON representation of your data.
                //MessageBox.Show(json);
                dataGrid.ItemsSource = patients;
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
            SearchPatients(searchKeyword);
        }

        public void SearchPatients(string searchKeyword)
        {
            try
            {
                // Create a list to store patient data matching the search keyword.
                List<Patients> matchingPatients = new List<Patients>();
                _dbManager.OpenConnection();

                // Perform a database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_patients WHERE " +
                        "FirstName LIKE @SearchKeyword OR " +
                        "MiddleName LIKE @SearchKeyword OR " +
                        "LastName LIKE @SearchKeyword OR " +
                        "Email LIKE @SearchKeyword OR " +
                        "Age LIKE @SearchKeyword OR " +
                        "BirthDate LIKE @SearchKeyword OR " +
                        "Address LIKE @SearchKeyword";

                    command.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");

                    // Execute the query and fetch data.
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the first column is the ID and the second column is the Name.
                            int id = reader.GetInt32(0);
                            string firstname = reader.GetString(1);
                            string middlename = reader.GetString(2);
                            string lastname = reader.GetString(3);
                            string email = reader.GetString(4);
                            int age = reader.GetInt32(5);
                            string birthdate = reader.GetString(6);
                            string address = reader.GetString(7);

                            // Add the matching patients to the list.
                            matchingPatients.Add(new Patients { Id = id, Firstname = firstname, Middlename = middlename, Lastname = lastname, Email = email, Age = age, BirthDate = birthdate, Address = address });
                        }
                    }
                }

                dataGrid.ItemsSource = matchingPatients;
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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.ShowAddPatient();
            ShowAddWindow();
        }
           

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("REFRESH");
            GetAllPatients();
        }

        private void ShowMainWindow()
        {
            sideBarPatient.Visibility = Visibility.Visible;
            gridAddPatient.Visibility = Visibility.Collapsed;
            gridPatient.Visibility = Visibility.Visible;
        }

        private void ShowAddWindow()
        {

            sideBarPatient.Visibility = Visibility.Collapsed;
                gridPatient.Visibility = Visibility.Collapsed;
                gridAddPatient.Visibility = Visibility.Visible;
            
        }

        private void ShowWindow_Click(object sender, RoutedEventArgs e)
        {
            ShowMainWindow();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Open the database connection.
                _dbManager.OpenConnection();

                // Create a new command object.
                SQLiteCommand command = _dbManager.CreateCommand();

                // Create the insert query.
                string query = "INSERT INTO tbl_patients (FirstName, MiddleName, LastName, Email, Age, BirthDate, Address, Password) VALUES (@Firstname, @Middlename, @Lastname, @Email, @Age, @Birthdate, @Address, @Password)";

                // Add the parameter values.
                command.CommandText = query;
                command.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                command.Parameters.AddWithValue("@Middlename", txtMiddlename.Text);
                command.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Age", txtAge.Text);
                command.Parameters.AddWithValue("@Birthdate", birthDate.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Password);


                // Execute the query.
                int rowsAffected = command.ExecuteNonQuery();

                // Close the database connection.
                _dbManager.CloseConnection();

                // Check if the query was successful.
                if (rowsAffected > 0)
                {
                    // The query was successful.
                    MessageBox.Show("The patient has been added successfully.");
                   
                }
                else
                {
                    // The query was not successful.
                    MessageBox.Show("Error: The patient could not be added.");
                }
                GetAllPatients();
            ShowMainWindow();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
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
