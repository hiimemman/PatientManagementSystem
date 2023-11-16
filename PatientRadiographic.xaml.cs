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
using System.Runtime.CompilerServices;
using System.Windows.Threading;

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

        private DispatcherTimer timer;

        public PatientRadiographic()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();



            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            this.DataContext = this;
        }

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
            get { return _patientId; }
            set
            {
                if (_patientId != value)
                {
                    _patientId = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }

        public string ReferenceNo
        {
            get { return _referenceNo; }
            set
            {
                if (_referenceNo != value)
                {
                    _referenceNo = value;
                    OnPropertyChanged(nameof(ReferenceNo));
                }
            }
        }

        public string TypeOfExam
        {
            get { return _typeOfExam; }
            set
            {
                if (_typeOfExam != value)
                {
                    _typeOfExam = value;
                    OnPropertyChanged(nameof(TypeOfExam));
                }
            }
        }

        public string DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    OnPropertyChanged(nameof(DateCreated));
                }
            }
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Call the GetData method
            GetData();
        }


        public async void GetData()
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

                   await using (SQLiteDataReader reader = command.ExecuteReader())
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


                          
                            this.Impression = impression;
                            this.Interpretation = interpretation;
                            this.PatientId = $"{patientId}";
                            this.ReferenceNo = referenceNo;
                            this.TypeOfExam = typeOfExam;
                            this.DateCreated = dateCreated;

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
                _dbManager.CloseConnection();
            }

        }


        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.LogoutPatient();
        }

      

        private void BtnGoToLabTest_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToPatientLabTest();
        }

        private void BtnPatientGoToDrugTest_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToPatientDrugTest();
        }

        private void BtnGoToPatientHerma_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToPatientHermatogloy();
        }

        private void BtnGoToPatientRadio_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToPatientRadiographic();
        }

        private void BtnGoToPatientFecalysis_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToPatientFecalysis();
        }

    }
}
