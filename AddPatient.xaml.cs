using PatientManagementSystem.Databases;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using Newtonsoft.Json;

namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : UserControl
    {
        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        public AddPatient()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
        }

        private void GoToPatient_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToPatient();
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
                string query = "INSERT INTO tbl_patients (firstName, middleName, lastName, email, age, birthDate, address, password) VALUES (@Firstname, @Middlename, @Lastname, @Email, @Age, @Birthdate, @Address, @Password)";

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
                command.ExecuteNonQuery();

                // Close the database connection.
                _dbManager.CloseConnection();

                // Show a message to the user.
                MessageBox.Show("The patient has been added successfully.");

                mainWindow.GoToPatient();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }

        }
    }
}
