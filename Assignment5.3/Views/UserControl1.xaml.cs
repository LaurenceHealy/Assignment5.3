using System;
using System.Collections.Generic;
using System.Data;
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


namespace Assignment5._3.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        
        public event EventHandler LogonSuccess;
        public event EventHandler LogonFailure;
        private void login_Click(object sender, RoutedEventArgs e)
        {
            var user = userName.Text;
            var pass = password.Password;
            if((user == "Teacher") && (pass == "Admin"))
            {
                userName.Text = null;
                password.Password = null;
                LogonSuccess(this, null);
                return;                
            }
            else
            {
                LogonFailure(this, null);
            }
            userName.Text = null;
            password.Password = null;   
        }
    }
}
