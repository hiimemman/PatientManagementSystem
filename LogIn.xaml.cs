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


namespace PatientManagementSystem
{

    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Date_Created { get; set; }
    }


    public partial class LogIn : UserControl
    {

        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;



        private DatabaseManager _dbManager;

        public LogIn()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager();


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                    command.CommandText = "SELECT * FROM tbl_users WHERE email = @Email AND password = @Password";
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            mainWindow.GoToPatient();
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
                // Handle exceptions
            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterHyperlink_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToRegister();
        }
    }


}
