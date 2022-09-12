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
using Assignment5._3.Views;

namespace Assignment5._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GoToLogon();
        }
        public void GoToLogon()
        {
            Logon.Visibility = Visibility.Visible;
            Entry.Visibility = Visibility.Collapsed;
        }

        private void Logon_Success(object sender, EventArgs e)
        {
            // Update the display and show the data for the logged on user
            Logon.Visibility = Visibility.Collapsed;
            Entry.Visibility = Visibility.Visible;
            
        }

        private void Logon_Failure(object sender, EventArgs e)
        {
            MessageBox.Show("Login Failure", "Invalid User Name or Password", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Log_Out(object sender, EventArgs e)
        {
            
            Logon.Visibility = Visibility.Visible;
            Entry.Visibility = Visibility.Collapsed;
        }
    }
}
