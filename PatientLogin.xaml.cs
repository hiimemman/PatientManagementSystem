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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using PatientManagementSystem.Classes;
using System.Diagnostics;

namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for PatientLogin.xaml
    /// </summary>
    public partial class PatientLogin : UserControl
    {

        //UserInformation[] userInformationArray = UserSession.UserInformationArray;
     

        private MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        PatientRadiographic radiographic = new PatientRadiographic();

        private DatabaseManager _dbManager;

        public PatientLogin()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager();
        }


        public void GoBackToChooseRole_Click(object sender, RoutedEventArgs e)
        {

            mainWindow.GoToChooseRole();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Email = txtEmail.Text;
                string password = txtPassword.Password;

                _dbManager.OpenConnection();


                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT Id, Email FROM tbl_patients WHERE email = @Email AND password = @Password";
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Check if the query returned any rows.
                        if (reader.HasRows)
                        {
                            // Read the first row.
                            reader.Read();

                            // Add the user information to the class array.
                            UserSession.AddUser(
                                new UserInformation()
                                {
                                    Id = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Role = "Patient"
                                }
                              
                            );

                            LoadAllData();
                            mainWindow.GoToPatientRadiographic();

                           
                        }
                        else
                        {
                            MessageBox.Show("Wrong Email or Password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               Debug.WriteLine("Error in patient login adding data: "+ex.Message);
            }
        }

        public void LoadAllData()
        {
            try
            {
                radiographic.GetData();

            }
            catch(Exception e)
            {
                Debug.WriteLine("Error in loading all data: " + e.Message);
            }
        }

    }
}
