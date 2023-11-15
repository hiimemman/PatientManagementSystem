using MahApps.Metro.Controls;
using PatientManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
     
        private LogIn loginPage;


        public MainWindow()
        {
            InitializeComponent();

            CloseLoadingScreen();
        }

        public void LogoutPatient()
        {
            UserSession.ClearUser();
            GoToPatientLogin();
        }

        public void LogoutAdmin()
        {
            GoToLogIn();
        }

        public void GoToPatientFecalysis()
        {
            patientLogin.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            patientContentGrid.Visibility = Visibility.Visible;
            patientRadiographicControl.Visibility = Visibility.Collapsed;
            patientLaboratoryTestControl.Visibility = Visibility.Collapsed;
            patientDrugTestControl.Visibility = Visibility.Collapsed;
            patientHermatologyControl.Visibility = Visibility.Collapsed;
            patientFecalysisControl.Visibility = Visibility.Visible;
        }

        public void GoToPatientHermatogloy()
        {
            patientLogin.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            patientContentGrid.Visibility = Visibility.Visible;
            patientRadiographicControl.Visibility = Visibility.Collapsed;
            patientLaboratoryTestControl.Visibility = Visibility.Collapsed;
            patientDrugTestControl.Visibility = Visibility.Collapsed;
            patientHermatologyControl.Visibility = Visibility.Visible;
            patientFecalysisControl.Visibility = Visibility.Collapsed;
        }

        public void GoToPatientDrugTest()
        {
            patientLogin.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            patientContentGrid.Visibility = Visibility.Visible;
            patientRadiographicControl.Visibility = Visibility.Collapsed;
            patientLaboratoryTestControl.Visibility = Visibility.Collapsed;
            patientDrugTestControl.Visibility = Visibility.Visible;
            patientHermatologyControl.Visibility = Visibility.Collapsed;
            patientFecalysisControl.Visibility = Visibility.Collapsed;
        }

        public void GoToPatientLabTest()
        {
            patientLogin.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            patientContentGrid.Visibility = Visibility.Visible;
            patientRadiographicControl.Visibility = Visibility.Collapsed;
            patientLaboratoryTestControl.Visibility = Visibility.Visible;
            patientDrugTestControl.Visibility = Visibility.Collapsed;
            patientHermatologyControl.Visibility = Visibility.Collapsed;
            patientFecalysisControl.Visibility = Visibility.Collapsed;
        }

        public void GoToPatientRadiographic()
        {
            
            patientLogin.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            patientContentGrid.Visibility = Visibility.Visible;
            patientRadiographicControl.Visibility = Visibility.Visible;
            patientLaboratoryTestControl.Visibility = Visibility.Collapsed;
            patientDrugTestControl.Visibility = Visibility.Collapsed;
            patientHermatologyControl.Visibility = Visibility.Collapsed;
            patientFecalysisControl.Visibility = Visibility.Collapsed;
        }

        public void GoToChooseRole()
        {
            loadingScreen.Visibility = Visibility.Hidden;
            chooseRole.Visibility = Visibility.Visible;
            registerControl.Visibility = Visibility.Collapsed;

            contentGrid.Visibility = Visibility.Collapsed;
            loginControl.Visibility = Visibility.Collapsed;

            patientContentGrid.Visibility = Visibility.Collapsed;
            patientLogin.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
        }

        public void GoToPatientLogin()
        {

            chooseRole.Visibility = Visibility.Collapsed;
            loadingScreen.Visibility = Visibility.Hidden;
            contentGrid.Visibility = Visibility.Collapsed;
            patientContentGrid.Visibility = Visibility.Collapsed;
            patientLogin.Visibility = Visibility.Visible;
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
        }

        public void GoToLogIn()
        {

            chooseRole.Visibility = Visibility.Collapsed;
            loadingScreen.Visibility = Visibility.Hidden;
            contentGrid.Visibility = Visibility.Collapsed;
            loginControl.Visibility = Visibility.Visible;
            patientContentGrid.Visibility = Visibility.Collapsed;
            patientLogin.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
        }

        public void GoToRegister()
        {
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Visible;
        }

        public void GoToDashboard()
        {
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Visible;
        }

        //pages

        public void GoToPatient()
        {
            contentGrid.Visibility = Visibility.Visible;

            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Visible;
            labTestControl.Visibility = Visibility.Collapsed;
            drugTestControl.Visibility = Visibility.Collapsed;
            fecalysisControl.Visibility = Visibility.Collapsed;
            hermatologyControl.Visibility = Visibility.Collapsed;
            radiographicControl.Visibility = Visibility.Collapsed;
            usersControl.Visibility = Visibility.Collapsed;
            userSettingsControl.Visibility = Visibility.Collapsed;
        }

        public void GoToLabTest()
        {
            contentGrid.Visibility = Visibility.Visible;

            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            labTestControl.Visibility = Visibility.Visible;
            drugTestControl.Visibility = Visibility.Collapsed;
            fecalysisControl.Visibility = Visibility.Collapsed;
            hermatologyControl.Visibility = Visibility.Collapsed;
            radiographicControl.Visibility = Visibility.Collapsed;
            usersControl.Visibility = Visibility.Collapsed;
            userSettingsControl.Visibility = Visibility.Collapsed;
        }

        public void GoToDrugTest()
        {
            contentGrid.Visibility = Visibility.Visible;

            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            labTestControl.Visibility = Visibility.Collapsed;
            drugTestControl.Visibility = Visibility.Visible;
            fecalysisControl.Visibility = Visibility.Collapsed;
            hermatologyControl.Visibility = Visibility.Collapsed;
            radiographicControl.Visibility = Visibility.Collapsed;
            usersControl.Visibility = Visibility.Collapsed;
            userSettingsControl.Visibility = Visibility.Collapsed;
        }

        public void GoToFecalysis()
        {
            contentGrid.Visibility = Visibility.Visible;

            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            labTestControl.Visibility = Visibility.Collapsed;
            drugTestControl.Visibility = Visibility.Collapsed;
            fecalysisControl.Visibility = Visibility.Visible;
            hermatologyControl.Visibility = Visibility.Collapsed;
            radiographicControl.Visibility = Visibility.Collapsed;
            usersControl.Visibility = Visibility.Collapsed;
            userSettingsControl.Visibility = Visibility.Collapsed;
        }

        public void GoToHematology()
        {
            contentGrid.Visibility = Visibility.Visible;
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            labTestControl.Visibility = Visibility.Collapsed;
            drugTestControl.Visibility = Visibility.Collapsed;
            fecalysisControl.Visibility = Visibility.Collapsed;
            hermatologyControl.Visibility = Visibility.Visible;
            radiographicControl.Visibility = Visibility.Collapsed;
            usersControl.Visibility = Visibility.Collapsed;
            userSettingsControl.Visibility = Visibility.Collapsed;
        }

        public void GoToRadiographic()
        {
            contentGrid.Visibility = Visibility.Visible;
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            labTestControl.Visibility = Visibility.Collapsed;
            drugTestControl.Visibility = Visibility.Collapsed;
            fecalysisControl.Visibility = Visibility.Collapsed;
            hermatologyControl.Visibility = Visibility.Collapsed;
            radiographicControl.Visibility = Visibility.Visible;
            usersControl.Visibility = Visibility.Collapsed;
            userSettingsControl.Visibility = Visibility.Collapsed;
        }

        public void GoToUsers()
        {
            contentGrid.Visibility = Visibility.Visible;
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Collapsed;
            labTestControl.Visibility = Visibility.Collapsed;
            drugTestControl.Visibility = Visibility.Collapsed;
            fecalysisControl.Visibility = Visibility.Collapsed;
            hermatologyControl.Visibility = Visibility.Collapsed;
            radiographicControl.Visibility = Visibility.Collapsed;
            usersControl.Visibility = Visibility.Visible;
            userSettingsControl.Visibility = Visibility.Collapsed;
        }

        public void GoToUserSettings()
        {
            //contentGrid.Visibility = Visibility.Visible;
            //loginControl.Visibility = Visibility.Collapsed;
            //registerControl.Visibility = Visibility.Collapsed;
            //dashboardControl.Visibility = Visibility.Collapsed;
            //patientControl.Visibility = Visibility.Collapsed;
            //labTestControl.Visibility = Visibility.Collapsed;
            //drugTestControl.Visibility = Visibility.Collapsed;
            //fecalysisControl.Visibility = Visibility.Collapsed;
            //hermatologyControl.Visibility = Visibility.Collapsed;
            //radiographicControl.Visibility = Visibility.Collapsed;
            //usersControl.Visibility = Visibility.Collapsed;
            //userSettingsControl.Visibility = Visibility.Visible;
        }

        public void ShowAddPatient()
        {
        
            contentGrid.Visibility = Visibility.Collapsed;
        }

        public async void CloseLoadingScreen()
        {
          
           
            await Task.Delay(5000);
            GoToChooseRole();
        }
    }
}
