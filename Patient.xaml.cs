using PatientManagementSystem.Databases;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using Newtonsoft.Json;


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
        public string Status { get; set; }
        public string Address { get; set; }
    }
    public partial class Patient : UserControl
    {
        private DatabaseManager _dbManager;

        // Create a list to store user data.
        List<Patients> patients = new List<Patients>();

        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        public Patient()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager();

            // Get all data from the database.
            GetAllPatients();


            dataGrid.ItemsSource = patients;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GetAllPatients()
        {

            try
            {
                _dbManager.OpenConnection();

               

                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_patients";

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

                            // Add the user to the list.
                            patients.Add(new Patients { Id = id, Firstname = firstname, Middlename = middlename, Lastname = lastname, Email = email, Age = age, BirthDate = birthdate, Address = address});

                        }
                    }


                }

                // Serialize the 'users' list to JSON.
                //string json = JsonConvert.SerializeObject(patients);

                // Now 'json' contains the JSON representation of your data.
                //MessageBox.Show(json);
               
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowAddPatient();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetAllPatients();
        }
    }
}
