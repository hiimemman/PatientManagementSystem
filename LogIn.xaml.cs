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

namespace PatientManagementSystem
{
   
    public partial class LogIn : UserControl
    {
        private DatabaseManager _dbManager;

        public LogIn()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dbManager.OpenConnection();

                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM YourTable";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process the query results.
                            string result = reader["ColumnName"].ToString();
                            // Perform some action with the result.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _dbManager.CloseConnection();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
