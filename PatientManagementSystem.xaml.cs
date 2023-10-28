using MahApps.Metro.Controls;
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

        public void GoToChooseRole()
        {
            loadingScreen.Visibility = Visibility.Hidden;
            chooseRole.Visibility = Visibility.Visible;
            registerControl.Visibility = Visibility.Collapsed;
        }

        public void GoToLogIn()
        {

            chooseRole.Visibility = Visibility.Collapsed;
            loadingScreen.Visibility = Visibility.Hidden;
            contentGrid.Visibility = Visibility.Visible;
            loginControl.Visibility = Visibility.Visible;
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

        public void GoToPatient()
        {
            contentGrid.Visibility = Visibility.Visible;
            addPatientControl.Visibility = Visibility.Collapsed;
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Visible;
        }

        public void ShowAddPatient()
        {
            addPatientControl.Visibility = Visibility.Visible;
            contentGrid.Visibility = Visibility.Collapsed;
        }

        public async void CloseLoadingScreen()
        {
          
           
            await Task.Delay(5000);
            GoToChooseRole();
        }
    }
}
