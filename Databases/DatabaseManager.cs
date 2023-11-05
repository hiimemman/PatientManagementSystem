using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace PatientManagementSystem.Databases
{
    public class DatabaseManager
    {
        private SQLiteConnection _connection;

        public DatabaseManager() 
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            // Define the database file path.
            string databasePath = "Databases/PatientManagementSystem.db"; // Replace with your database file path.

            // Check if the database file exists.
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
    
            }

            // Create the SQLite connection.
            string connectionString = $"Data Source={databasePath};Version=3;";
            _connection = new SQLiteConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SQLiteCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }
    }
}
