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
    /// <summary>
    /// Interaction logic for PatientLaboratoryTest.xaml
    /// </summary>
    public partial class PatientLaboratoryTest : UserControl, INotifyPropertyChanged
    {


        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        //static List<UserInformation> userInformationArray = UserSession.UserInformationArray;

        private static List<IRadiographic> userData = new List<IRadiographic>();

        List<UserInformation> userInformation = new List<UserInformation>();

        private DispatcherTimer timer;
        public PatientLaboratoryTest()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager();



            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Call the GetData method
            GetData();
        }

        private string _testName;
        private string _testDate;
        private string _testResult;
        private string _referenceRange;
        private string _employeeAssignedId;
        private string _patientId;
        private string _labLocation;

        public string TestName
        {
            get { return  _testName; }
            set
            {
                if( _testName != value)
                {
                    _testName = value;
                    OnPropertyChanged(nameof(TestName));
                }
            }
        }

        public string TestDate
        {
            get { return _testDate; }

            set
            {
                if(_testDate != value)
                {
                    _testDate = value;
                    OnPropertyChanged(nameof(TestDate));
                }
            }

        }

        public string TestResult
        {
            get { return _testResult; }
            set
            {
                if(_testResult != value)
                {
                    _testResult = value;
                    OnPropertyChanged(nameof(TestResult));
                }
            }
        }

        public string ReferenceRange
        {
            get { return _referenceRange; }
            set
            {
                if( value != _referenceRange)
                {
                    _referenceRange = value;
                    OnPropertyChanged(nameof(ReferenceRange));
                }
            }
        }
        public string EmployeeAssignedId
        {
            get { return _employeeAssignedId;  }
            set
            {
                if( _employeeAssignedId != value)
                {
                    _employeeAssignedId = value;
                    OnPropertyChanged(nameof(EmployeeAssignedId));
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

        public string LabLocation
        {
            get { return _labLocation; }
            set
            {
                if(_labLocation != value)
                {
                    _labLocation = value;
                    OnPropertyChanged(nameof(LabLocation));
                }
            }
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
                    command.CommandText = "SELECT * FROM tbl_laboratoryTest WHERE patientId = @ID";
                    command.Parameters.AddWithValue("@ID", _patientId);

                    await using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Check if the query returned any rows.
                        if (reader.HasRows)
                        {
                            // Read the first row.
                            reader.Read();
                            int id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            Debug.WriteLine("THIS IS THE ID" + id);

                            //this.PatientId = reader.IsDBNull(1) ? "0" : $"{reader.GetInt32(1)}";

                            //this.Color = reader.IsDBNull(2) ? "" : reader.GetString(2);

                            //this.OccultBlood = reader.IsDBNull(3) ? "" : reader.GetString(3);

                            //this.PusCells = reader.IsDBNull(4) ? "" : reader.GetString(4);

                            //this.RedBloodCells = reader.IsDBNull(5) ? "" : reader.GetString(5);

                            //this.Cyst = reader.IsDBNull(6) ? "" : reader.GetString(6);

                            //this.Trophozolte = reader.IsDBNull(7) ? "" : reader.GetString(7);

                            //this.IntestinalParasite = reader.IsDBNull(8) ? "" : reader.GetString(8);

                            //this.Consistency = reader.IsDBNull(9) ? "" : reader.GetString(9);

                            //this.Pathologist = reader.IsDBNull(10) ? "" : reader.GetString(10);

                            //this.MedicalTechnoglogist = reader.IsDBNull(11) ? "" : reader.GetString(11);

                            //this.DateCreated = reader.IsDBNull(12) ? "" : reader.GetString(12);

                            this.TestName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            this.TestDate = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            this.TestResult = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            this.ReferenceRange = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            this.EmployeeAssignedId = reader.IsDBNull(5) ? "0" : $"{reader.GetInt32(5)}";
                            this.PatientId = reader.IsDBNull(6) ? "0" : $"{reader.GetInt32(6)}";
                            this.LabLocation = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            //this.Impression = impression;
                            //this.Interpretation = interpretation;
                            //this.PatientId = $"{patientId}";
                            //this.ReferenceNo = referenceNo;
                            //this.TypeOfExam = typeOfExam;
                            //this.DateCreated = dateCreated;

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
