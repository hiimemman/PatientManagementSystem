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
    /// Interaction logic for PatientDrugTest.xaml
    /// </summary>
    public partial class PatientDrugTest : UserControl, INotifyPropertyChanged
    {


        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        //static List<UserInformation> userInformationArray = UserSession.UserInformationArray;

        private static List<IDrugTest> userData = new List<IDrugTest>();

        List<UserInformation> userInformation = new List<UserInformation>();

        private DispatcherTimer timer;

        public PatientDrugTest()
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
        private int _patientId;
        public int PatientId
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

        private string _ccfNo;
        public string CCFNO
        {
            get { return _ccfNo; }
            set
            {
                if (_ccfNo != value)
                {
                    _ccfNo = value;
                    OnPropertyChanged(nameof(CCFNO));
                }
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private DateTime _transactionDate;
        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set
            {
                if (_transactionDate != value)
                {
                    _transactionDate = value;
                    OnPropertyChanged(nameof(TransactionDate));
                }
            }
        }

        private string _reportDate;
        public string ReportDate
        {
            get { return _reportDate; }
            set
            {
                if (_reportDate != value)
                {
                    _reportDate = value;
                    OnPropertyChanged(nameof(ReportDate));
                }
            }
        }

        private string _testMethod;
        public string TestMethod
        {
            get { return _testMethod; }
            set
            {
                if (_testMethod != value)
                {
                    _testMethod = value;
                    OnPropertyChanged(nameof(TestMethod));
                }
            }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        private string _purpose;
        public string Purpose
        {
            get { return _purpose; }
            set
            {
                if (_purpose != value)
                {
                    _purpose = value;
                    OnPropertyChanged(nameof(Purpose));
                }
            }
        }

        private string _requestingParties;
        public string RequestingParties
        {
            get { return _requestingParties; }
            set
            {
                if (_requestingParties != value)
                {
                    _requestingParties = value;
                    OnPropertyChanged(nameof(RequestingParties));
                }
            }
        }

        private string _methResult;
        public string MethResult
        {
            get { return _methResult; }
            set
            {
                if (_methResult != value)
                {
                    _methResult = value;
                    OnPropertyChanged(nameof(MethResult));
                }
            }
        }

        private string _methRemarks;
        public string MethRemarks
        {
            get { return _methRemarks; }
            set
            {
                if (_methRemarks != value)
                {
                    _methRemarks = value;
                    OnPropertyChanged(nameof(MethRemarks));
                }
            }
        }

        private string _tetraResult;
        public string TetraResult
        {
            get { return _tetraResult; }
            set
            {
                if (_tetraResult != value)
                {
                    _tetraResult = value;
                    OnPropertyChanged(nameof(TetraResult));
                }
            }
        }

        private string _tetraRemarks;
        public string TetraRemarks
        {
            get { return _tetraRemarks; }
            set
            {
                if (_tetraRemarks != value)
                {
                    _tetraRemarks = value;
                    OnPropertyChanged(nameof(TetraRemarks));
                }
            }
        }

        private string _analyst;
        public string Analyst
        {
            get { return _analyst; }
            set
            {
                if (_analyst != value)
                {
                    _analyst = value;
                    OnPropertyChanged(nameof(Analyst));
                }
            }
        }

        private string _headOfLab;
        public string HeadOfLab
        {
            get { return _headOfLab; }
            set
            {
                if (_headOfLab != value)
                {
                    _headOfLab = value;
                    OnPropertyChanged(nameof(HeadOfLab));
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
                    command.CommandText = "SELECT * FROM tbl_drugTest WHERE patientId = @ID";
                    command.Parameters.AddWithValue("@ID", _patientId);

                    await using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Check if the query returned any rows.
                        if (reader.HasRows)
                        {
                            // Read the first row.
                            reader.Read();

                            this.PatientId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            this.CCFNO = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            this.FullName = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            this.TransactionDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                            this.ReportDate = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            this.TestMethod = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            this.Gender = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            this.Purpose = reader.IsDBNull(8) ? "" : reader.GetString(8);
                            this.RequestingParties = reader.IsDBNull(9) ? "" : reader.GetString(9);
                            this.MethResult = reader.IsDBNull(10) ? "" : reader.GetString(10);
                            this.MethRemarks = reader.IsDBNull(11) ? "" : reader.GetString(11);
                            this.TetraResult = reader.IsDBNull(12) ? "" : reader.GetString(12);
                            this.TetraRemarks = reader.IsDBNull(13) ? "" : reader.GetString(13);
                            this.Analyst = reader.IsDBNull(14) ? "" : reader.GetString(14);
                            this.HeadOfLab = reader.IsDBNull(15) ? "" : reader.GetString(15);
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
