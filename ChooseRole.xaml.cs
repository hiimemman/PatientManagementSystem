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
    /// Interaction logic for ChooseRole.xaml
    /// </summary>
    public partial class ChooseRole : UserControl
    {
        // Assuming you have a reference to the MainWindow instance
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;


        public ChooseRole()
        {
            InitializeComponent();
        }

        public void GoToAdminLogin()
        {
            mainWindow.GoToLogIn();
        }

        public void GoToLogIn_Click(object sender, RoutedEventArgs e)
        {
            GoToAdminLogin();
        }
    }
}
