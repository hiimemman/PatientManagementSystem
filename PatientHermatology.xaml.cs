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
    /// Interaction logic for PatientHermatology.xaml
    /// </summary>
    public partial class PatientHermatology : UserControl, INotifyPropertyChanged
    {

        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        //static List<UserInformation> userInformationArray = UserSession.UserInformationArray;

        private static List<IRadiographic> userData = new List<IRadiographic>();

        List<UserInformation> userInformation = new List<UserInformation>();

        private DispatcherTimer timer;


        public PatientHermatology()
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

        private string _patientId;
        private string _referenceNumber;
        private string _hgb;
        private string _hct;
        private string _rbc;
        private string _wbc;
        private string _esr;
        private string _platelet;
        private string _bloodType;
        private string _segmenters;
        private string _lymphocytes;
        private string _monocytes;
        private string _eosinophils;
        private string _basophils;
        private string _bands;
        private string _color;
        private string _transparency;
        private string _react;
        private string _specificGravity;
        private string _sugar;
        private string _albumin;
        private string _pregnancyTest;
        private string _method;
        private string _epithelialCell;
        private string _pusCell;
        private string _redCell;
        private string _amorphousSubs;
        private string _mucousThreads;
        private string _bacteria;
        private string _others;
        private string _crystals;
        private string _parasites;
        private string _medicalTechnologistName;
        private string _pathologistName;

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

        public string ReferenceNumber
        {
            get { return _referenceNumber;  }
            set
            {
                if (_referenceNumber != value)
                {
                    _referenceNumber = value;
                    OnPropertyChanged(nameof(ReferenceNumber));
                }
            }
        }
        public string HGB
        {
            get { return _hgb; }

            set
            {
                if (_hgb != value)
                {
                    _hgb = value;
                    OnPropertyChanged(nameof(HGB));

                }
            }
        }

        public string HCT
        {
            get { return _hct; }
            set
            {
                if (value != _hct)
                {
                    _hct = value;
                    OnPropertyChanged(nameof(HCT));

                }
            }
        }
        public string RBC
        {
            get { return _rbc; }
            set
            {
                if(value != _rbc)
                {
                    _rbc = value;
                    OnPropertyChanged(nameof(RBC));
                }
            }
        }

        public string WBC
        {
            get { return _wbc; }
            set
            {
                if(value != _wbc)
                {
                    _wbc = value;
                    OnPropertyChanged(nameof(WBC));

                }
            }
        }
        public string ESR
        {
            get { return _esr; }
            set
            {
                if( value != _esr)
                {
                    _esr = value;
                    OnPropertyChanged(nameof(ESR));

                }
            }
        }

        public string Platelet
        {
            get { return _platelet; }
            set
            {
                if (value != _platelet)
                {
                    _platelet = value;
                    OnPropertyChanged(nameof(Platelet));
                }
            }
        }

        public string BloodType
        {
            get { return _bloodType; }
            set
            {
                if( _bloodType != value)
                {
                    _bloodType = value;
                    OnPropertyChanged(nameof(BloodType));

                }
            }
        }

        public string Segmenters
        {
            get { return _segmenters; }
            set 
            { 
                if(_segmenters != value)
                {
                    _segmenters = value;
                    OnPropertyChanged(nameof(Segmenters));
                }
            }
        }

        public string Lymphocytes
        {
            get { return _lymphocytes; }
            set
            {
                if(_lymphocytes != value)
                {
                    _lymphocytes = value;
                    OnPropertyChanged(nameof(Lymphocytes));
                }
            }
        }

        public string Monocytes
        {
            get { return _monocytes; }
            set
            {
                if( (_monocytes != value))
                {
                    _monocytes = value;
                    OnPropertyChanged(nameof(Monocytes));
                }
            }
        }

        public string Eosinophils
        {
            get { return _eosinophils; }
            set
            {
                if(_eosinophils != value)
                {
                    _eosinophils = value;
                    OnPropertyChanged(nameof(Eosinophils));
                }
            }
        }

        public string Basophils
        {
            get { return _basophils; }

            set
            {
                if( _basophils != value)
                {
                    _basophils = value;
                    OnPropertyChanged(nameof(Basophils));
                }
            }
        }

        public string Bands
        {
            get { return _bands; }
            set
            {
                if(_bands != value)
                {
                    _bands = value;
                    OnPropertyChanged(nameof(Bands));
                }
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        public string Transparency
        {
            get { return _transparency; }
            set
            {
                if( (_transparency != value))
                {
                    _transparency = value;
                    OnPropertyChanged(nameof(Transparency));

                }
            }
        }

        public string React
        {
            get { return _react; }
            set
            {
                if( _react != value)
                {
                    _react = value;
                    OnPropertyChanged(nameof(React));

                }
            }
        }

        public string SpecificGravity
        {
            get { return _specificGravity; }
            set
            {
                if(_specificGravity != value)
                {
                    _specificGravity = value;
                    OnPropertyChanged(nameof(SpecificGravity));
                }
            }
        }

        public string Sugar
        {
            get { return _sugar; }
            set
            {
                if(_sugar  != value)
                {
                    _sugar = value;
                    OnPropertyChanged(nameof(Sugar));
                }
            }
        }

        public string Albumin
        {
            get { return _albumin; }
            set
            {
                if(_albumin != value)
                {
                    _albumin = value;
                    OnPropertyChanged(nameof(Albumin));
                }
            }
        }

        public string PregnancyTest
        {
            get { return _pregnancyTest; }
            set
            {
                if (_pregnancyTest != value)
                {
                    _pregnancyTest = value;
                    OnPropertyChanged(nameof(PregnancyTest));
                }
            }
        }

        public string Method
        {
            get { return _method; }
            set
            {
                if (value != _method)
                {
                    _method = value;
                    OnPropertyChanged(nameof(Method));
                }
            }
        }

        public string EpithelialCell
        {
            get { return _epithelialCell;}
            set
            {
                if(value != _epithelialCell)
                {
                    _epithelialCell = value;
                    OnPropertyChanged(nameof(EpithelialCell));
                }
            }
        }

        public string PusCell
        {
            get { return _pusCell; }
            set
            {
                if(_pusCell != value)
                {
                    _pusCell = value;
                    OnPropertyChanged(nameof(PusCell));
                }
            }
        }

        public string RedCell
        {
            get { return _redCell; }
            set
            {
                if( value != _redCell)
                {
                    _redCell = value;
                    OnPropertyChanged(nameof(RedCell));
                }
            }
        }

        public string AmorphousSubs
        {
            get { return _amorphousSubs; }
            set
            {
                if(_amorphousSubs != value)
                {
                    _amorphousSubs = value;
                    OnPropertyChanged(nameof(AmorphousSubs));
                }
            }
        }

        public string MucousThreads
        {
            get { return _mucousThreads; }
            set
            {
                if( _mucousThreads != value)
                {
                    _mucousThreads = value;
                    OnPropertyChanged(nameof(MucousThreads));
                }
            }
        }

        public string Bacteria
        {
            get { return _bacteria; }
            set
            {
                if(_bacteria != value)
                {
                    _bacteria = value;
                    OnPropertyChanged(nameof(Bacteria));
                }
            }
        }

        public string Others
        {
            get { return _others; }
            set
            {
                if ( _others != value)
                {
                    _others = value;
                    OnPropertyChanged(nameof(Others));
                }
            }
        }

        public string Crystals
        {
            get { return _crystals; }

            set
            {
                if( (_crystals != value))
                {
                    _crystals = value;
                    OnPropertyChanged(nameof(Crystals));
                }
            }
        }


        public string Parasites
        {
            get { return _parasites; }
            set
            {
                if(  _parasites != value)
                {
                    _parasites = value;
                    OnPropertyChanged(nameof(Parasites));
                }
            }
        }

        public string MedicalTechnologist
        {
            get { return _medicalTechnologistName; }
            set
            {
                if(_medicalTechnologistName != value)
                {
                    _medicalTechnologistName = value;
                    OnPropertyChanged(nameof(MedicalTechnologist));
                }
            }
        }

        public string Pathologist
        {
            get { return _pathologistName;  }
            set
            {
                if( ( _pathologistName != value))
                {
                    _pathologistName = value;
                    OnPropertyChanged(nameof(Pathologist));
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
                    command.CommandText = "SELECT * FROM tbl_hematologyUrinalysis WHERE patientId = @ID";
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

                      

                            //this.TestName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            //this.TestDate = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            //this.TestResult = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            //this.ReferenceRange = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            //this.EmployeeAssignedId = reader.IsDBNull(5) ? "0" : $"{reader.GetInt32(5)}";
                            //this.PatientId = reader.IsDBNull(6) ? "0" : $"{reader.GetInt32(6)}";
                            //this.LabLocation = reader.IsDBNull(7) ? "" : reader.GetString(7);


                        this.PatientId = reader.IsDBNull(1) ? "NOT AVAILABLE" : $"{reader.GetInt32(1)}";

                        this.ReferenceNumber = reader.IsDBNull(2) ? "" : reader.GetString(2);

                        this.HGB = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        this.HCT = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        this.RBC = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        this.WBC = reader.IsDBNull(6) ? "" : reader.GetString(6);
                        this.ESR = reader.IsDBNull(7) ? "" : reader.GetString(7);
                        this.Platelet = reader.IsDBNull(8) ? "" : reader.GetString(8);
                        this.BloodType = reader.IsDBNull(9) ? "" : reader.GetString(9);
                        this.Segmenters = reader.IsDBNull(10) ? "" : reader.GetString(10);
                        this.Lymphocytes = reader.IsDBNull(11) ? "" : reader.GetString(11);
                        this.Monocytes = reader.IsDBNull(12) ? "" : reader.GetString(12);
                        this.Eosinophils = reader.IsDBNull(13) ? "" : reader.GetString(13);
                        this.Basophils = reader.IsDBNull(14) ? "" : reader.GetString(14);
                        this.Bands = reader.IsDBNull(15) ? "" : reader.GetString(15);
                        this.Color = reader.IsDBNull(16) ? "" : reader.GetString(16);
                        this.Transparency = reader.IsDBNull(17) ? "" : reader.GetString(17);
                        this.React = reader.IsDBNull(18) ? "" : reader.GetString(18);
                        this.SpecificGravity = reader.IsDBNull(19) ? "" : reader.GetString(19);
                        this.Sugar = reader.IsDBNull(20) ? "" : reader.GetString(20);
                        this.Albumin = reader.IsDBNull(21) ? "" : reader.GetString(21);
                        this.PregnancyTest = reader.IsDBNull(22) ? "" : reader.GetString(22);
                        this.Method = reader.IsDBNull(23) ? "" : reader.GetString(23);
                        this.EpithelialCell = reader.IsDBNull(24) ? "" : reader.GetString(24);
                        this.PusCell = reader.IsDBNull(24) ? "" : reader.GetString(24);
                        this.RedCell = reader.IsDBNull(25) ? "" : reader.GetString(25);
                        this.AmorphousSubs = reader.IsDBNull(26) ? "" : reader.GetString(26);
                        this.MucousThreads = reader.IsDBNull(27) ? "" : reader.GetString(27);
                        this.Bacteria = reader.IsDBNull(28) ? "" : reader.GetString(28);
                        this.Others = reader.IsDBNull(29) ? "" : reader.GetString(29);
                        this.Crystals = reader.IsDBNull(30) ? "" : reader.GetString(30);
                        this.Parasites = reader.IsDBNull(31) ? "" : reader.GetString(31);
                        this.MedicalTechnologist = reader.IsDBNull(32) ? "" : reader.GetString(32);
                        this.Pathologist = reader.IsDBNull(32) ? "" : reader.GetString(32);



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
