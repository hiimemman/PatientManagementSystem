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

namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {

        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        
        private DatabaseManager _dbManager;
        public Register()
        {


            _dbManager = new DatabaseManager();
            InitializeComponent();
        }


        private void GoToLogin_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToLogIn();
        }

        private Boolean CheckIfInputAreValid() {

            string Firstname = txtFirstname.Text;
            string Lastname = txtLastname.Text;
            string Email = txtEmail.Text;
            string Password = txtPassword.Password;
            string ConfirmPassword = txtConfirmPassword.Password;

            if(Firstname == "" || Lastname == "" || Email == "" || Password == "" || ConfirmPassword == "" || Password != ConfirmPassword)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private void RegisterSubmit_Click(object sender, RoutedEventArgs args)
        {
           if(CheckIfInputAreValid())
            {
                try
                {
                    _dbManager.OpenConnection();

                    string Firstname = txtFirstname.Text;
                    string Lastname = txtLastname.Text;
                    string Email = txtEmail.Text;
                    string Password = txtPassword.Password;
                    string ConfirmPassword = txtConfirmPassword.Password;

                    // Create and execute an INSERT query.
                    using (SQLiteCommand command = _dbManager.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO tbl_users (email, password, firstname, lastname) VALUES (@Email, @Password, @FirstName, @LastName)";
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@FirstName", Firstname);
                        command.Parameters.AddWithValue("@LastName", Lastname);
                        command.ExecuteNonQuery();

                        // Optional: Display a success message.
                        MessageBox.Show("User registered successfully.");
                    }

                }
                catch(Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Please fill up all the fields.");
            }
        }
    }
}
