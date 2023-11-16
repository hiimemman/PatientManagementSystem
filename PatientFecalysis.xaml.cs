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
    /// Interaction logic for PatientFecalysis.xaml
    /// </summary>
    public partial class PatientFecalysis : UserControl, INotifyPropertyChanged
    {

        private DatabaseManager _dbManager;
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        //static List<UserInformation> userInformationArray = UserSession.UserInformationArray;

        private static List<IRadiographic> userData = new List<IRadiographic>();

        List<UserInformation> userInformation = new List<UserInformation>();

        private DispatcherTimer timer;


        public PatientFecalysis()
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
        private string _color;
        private string _occultBlood;
        private string _pusCells;
        private string _redBloodCells;
        private string _cyst;
        private string _trophozolte;
        private string _intestinalParasite;
        private string _consistency;
        private string _pathologist;
        private string _medicalTechnologist;
        private string _dateCreated;


        public string PatientId
        {
            get { return _patientId;  }
            set
            {
                if (_patientId != value)
                {
                    _patientId = value;
                    OnPropertyChanged(nameof(PatientId));
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
        public string OccultBlood
        {
            get { return _occultBlood;}
            set
            {
                if (value != _occultBlood)
                {
                    _occultBlood = value;
                    OnPropertyChanged(nameof(OccultBlood));
                }
            }
        }
        
        public string PusCells
        {
            get { return _pusCells;  }
            set
            {
                if(value != _pusCells)
                {
                    _pusCells = value;
                    OnPropertyChanged(nameof(PusCells));
                }
            }
        }

        public string RedBloodCells
        {
            get { return _redBloodCells; }
            set 
            {
                if(value != _redBloodCells)
                {
                    _redBloodCells = value;
                    OnPropertyChanged(nameof(RedBloodCells));
                }
            }
        }

        public string Cyst
        {
            get { return _cyst; }

            set
            {
                if( value != _cyst)
                {
                    _cyst = value;
                    OnPropertyChanged(nameof(Cyst));
                }
            }
        }

        public string Trophozolte
        {
            get { return _trophozolte; }

            set
            {
                if (_trophozolte != value)
                {
                    _trophozolte = value;
                    OnPropertyChanged(nameof(Trophozolte));
                }
            }
        }
        
        public string IntestinalParasite
        {
            get { return _intestinalParasite; }

            set
            {
                if( _intestinalParasite != value)
                {
                    _intestinalParasite = value;
                    OnPropertyChanged(nameof(IntestinalParasite));
                }
            }
        }

        public string Consistency
        {
            get { return _consistency; }
            set
            {
                if(_consistency != value)
                {
                    _consistency = value;
                    OnPropertyChanged(nameof(Consistency));
                }
            }
        }

        public string Pathologist
        {
            get { return _pathologist; }

            set
            {
                if(_pathologist != value)
                {
                    OnPropertyChanged(nameof(Pathologist));
                }
            }
        }

        public string MedicalTechnoglogist
        {
            get { return _medicalTechnologist; }

            set
            {
                if(_medicalTechnologist != value)
                {
                    OnPropertyChanged(nameof(MedicalTechnoglogist));
                }
            }
        }

        public string DateCreated
        {
            get { return _dateCreated;  }

            set
            {
                if(_dateCreated != value)
                {
                    OnPropertyChanged(nameof(DateCreated));
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
                    command.CommandText = "SELECT * FROM tbl_fecalysis WHERE patientId = @ID";
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

                            //string impression = reader.IsDBNull(1) ? null : reader.GetString(1);

                            //string interpretation = reader.IsDBNull(2) ? null : reader.GetString(2);

                            //int patientId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                            //string referenceNo = reader.IsDBNull(4) ? null : reader.GetString(4);

                            //string typeOfExam = reader.IsDBNull(5) ? null : reader.GetString(5);


                            //string dateCreated = reader.IsDBNull(6) ? null : reader.GetString(6);
                            this.PatientId = reader.IsDBNull(1) ? "0" : $"{reader.GetInt32(1)}";

                            this.Color = reader.IsDBNull(2) ? "" : reader.GetString(2);

                            this.OccultBlood = reader.IsDBNull(3) ? "" : reader.GetString(3);

                            this.PusCells = reader.IsDBNull(4) ? "" : reader.GetString(4);

                            this.RedBloodCells = reader.IsDBNull(5) ? "" : reader.GetString(5);
                           
                            this.Cyst = reader.IsDBNull(6) ? "" : reader.GetString(6);

                            this.Trophozolte = reader.IsDBNull(7) ? "" : reader.GetString(7);
                            
                            this.IntestinalParasite = reader.IsDBNull(8) ? "" : reader.GetString(8);

                            this.Consistency = reader.IsDBNull(9) ? "" : reader.GetString(9);

                            this.Pathologist = reader.IsDBNull(10) ? "" : reader.GetString(10);

                            this.MedicalTechnoglogist = reader.IsDBNull(11) ? "" : reader.GetString(11);

                            this.DateCreated = reader.IsDBNull(12) ? "" : reader.GetString(12);

                            Console.WriteLine(Pathologist);
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
