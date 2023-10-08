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
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : UserControl
    {
        public LoadingScreen()
        {
            InitializeComponent();
            try
            {
                loadingVideo.Source = new Uri("assets/images/ezarate-loading.wmv", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting video source: {ex.Message}");
            }
        }
        public void PlayVideo()
        {
            loadingVideo.Play();
            MessageBox.Show("TITE");
        }
    }
}
