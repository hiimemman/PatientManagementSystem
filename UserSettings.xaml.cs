using PatientManagementSystem.Classes;
using PatientManagementSystem.Databases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : UserControl
    {
        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        public UserSettings()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
        }

        public void UpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int _userId = AdminSession.UserInformationArray[0].Id;
                string currentPassword = AdminSession.UserInformationArray[0].Password;

                if(txtCurrentPassword.Text == currentPassword)
                {
                    _dbManager.OpenConnection();

                    string newPassword = txtNewPassword.Text;
                    string confirmPassword = txtConfirmPassword.Text;
                    if (txtConfirmPassword.Text.Equals(txtNewPassword.Text))
                    {
                        SQLiteCommand command = _dbManager.CreateCommand();
                        // Assuming your table name is tbl_users and the password column is Password
                        string query = $"UPDATE tbl_users SET password = '{newPassword}' WHERE id = {_userId}";

                        command.CommandText = query;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Password updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("PASSWORD DOES NOT MATCH!");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password!");
                }
             

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
