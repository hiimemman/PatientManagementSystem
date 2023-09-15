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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the login page
            LogIn loginPage = new LogIn();
            //contentControl.Content = loginPage;

            //btnLogin.Visibility = Visibility.Collapsed;
        }

        private void LaunchGitHubSite_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Testing");
        }

        private void DeployCupCakes_Click(object sender, RoutedEventArgs e)
        {
            // deploy some CupCakes...
        }
    }
}
