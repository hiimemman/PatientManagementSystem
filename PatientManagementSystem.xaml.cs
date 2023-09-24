using MahApps.Metro.Controls;
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

            
        }


        public void GoToLogIn()
        {
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
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Collapsed;
            dashboardControl.Visibility = Visibility.Collapsed;
            patientControl.Visibility = Visibility.Visible;
        }
    }
}
