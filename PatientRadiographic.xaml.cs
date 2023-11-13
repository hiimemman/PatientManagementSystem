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
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Media;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics;
using PatientManagementSystem.Classes;
using System.ComponentModel;

namespace PatientManagementSystem
{
   
    public partial class PatientRadiographic : UserControl, INotifyPropertyChanged
    {
        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        //static List<UserInformation> userInformationArray = UserSession.UserInformationArray;

        private static List<IRadiographic> userData = new List<IRadiographic>();

        List<UserInformation> userInformation = new List<UserInformation>();

        //public string patientId { get; set; } = "0000";

        private string _impression;
        private string _interpretation;
        private string _patientId;
        private string _referenceNo;
        private string _typeOfExam;
        private string _dateCreated;

        public string Impression
        {
            get { return _impression; }
            set
            {
                if (_impression != value)
                {
                    _impression = value;
                    OnPropertyChanged(nameof(Impression));
                }
            }
        }

        public string Interpretation
        {
            get { return _interpretation; }
            set
            {
                if (_interpretation != value)
                {
                    _interpretation = value;
                    OnPropertyChanged(nameof(Interpretation));
                }
            }
        }

        public string PatientId
        {
            get { return _interpretation; }
            set
            {
                if (_interpretation != value)
                {
                    _interpretation = value;
                    OnPropertyChanged(nameof(Interpretation));
                }
            }
        }

        public string ReferenceNo
        {
            get { return _interpretation; }
            set
            {
                if (_interpretation != value)
                {
                    _interpretation = value;
                    OnPropertyChanged(nameof(Interpretation));
                }
            }
        }

        public string TypeOfExam
        {
            get { return _interpretation; }
            set
            {
                if (_interpretation != value)
                {
                    _interpretation = value;
                    OnPropertyChanged(nameof(Interpretation));
                }
            }
        }

        public string DateCreated
        {
            get { return _interpretation; }
            set
            {
                if (_interpretation != value)
                {
                    _interpretation = value;
                    OnPropertyChanged(nameof(Interpretation));
                }
            }
        }

        public PatientRadiographic()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
            GetData();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetData()
        {

            try
            {

                userInformation = UserSession.GetUserInformation();


                Debug.WriteLine("THIS IS THE TEST");

                Debug.WriteLine("THIS IS THE SIZE: " + UserSession.UserInformationArray.Count);

                int _patientId = UserSession.UserInformationArray[0].Id;

        
                _dbManager.OpenConnection();


                // Perform your database query using a SQLiteCommand.
                using (SQLiteCommand command = _dbManager.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM tbl_radiographic WHERE patientId = @ID";
                    command.Parameters.AddWithValue("@ID", _patientId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Check if the query returned any rows.
                        if (reader.HasRows)
                        {
                            // Read the first row.
                            reader.Read();
                            int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);

                            string impression = reader.IsDBNull(1) ? null : reader.GetString(1);

                            string interpretation = reader.IsDBNull(2) ? null : reader.GetString(2);

                            int patientId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                            string referenceNo = reader.IsDBNull(4) ? null : reader.GetString(4);

                            string typeOfExam = reader.IsDBNull(5) ? null : reader.GetString(5);

                            string dateCreated = reader.IsDBNull(6) ? null : reader.GetString(6);

                            //userData.Add(
                            //new IRadiographic
                            //{
                            //    Id = id,
                            //    Impression = impression,
                            //    Interpretation = interpretation,
                            //    PatientId = patientId,
                            //    ReferenceNo = referenceNo,
                            //    TypeOfExam = typeOfExam,
                            //    DateCreated = dateCreated

                            //});

                            //Impression = impression;
                            //Interpretation = interpretation;
                            //PatientId = $"{patientId}";
                            //ReferenceNo = referenceNo;
                            //TypeOfExam = typeOfExam;
                            //DateCreated = DateCreated;

                            Impression = impression;
                            Interpretation = interpretation;
                            PatientId = $"{patientId}";
                            ReferenceNo = reader.IsDBNull(4) ? null : reader.GetString(4);
                            TypeOfExam = reader.IsDBNull(5) ? null : reader.GetString(5);
                            DateCreated = reader.IsDBNull(6) ? null : reader.GetString(6);

                        }
                        else
                        {
                            MessageBox.Show("Wrong Email or Password");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in adding data" + e.Message);
            }
            finally
            {
                DisplayData();
            }

        }

        public  void  DisplayData()
        {
            try
            {
                //lblRadioId.Text = "TESTING NATEN";

            }
            catch (Exception e) { Debug.WriteLine("Error in displaying data" + e.Message); }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.LogoutPatient();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }
    }
}
