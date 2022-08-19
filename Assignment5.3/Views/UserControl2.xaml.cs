using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Text.RegularExpressions;
using System.IO;

namespace Assignment5._3.Views
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public event EventHandler Return;

        public List<Student> sortStudents = new List<Student>();
        public ObservableCollection<Student> students = new ObservableCollection<Student>(); 
        public UserControl2()
        {
            InitializeComponent();
            studentList.ItemsSource = students;

            CollectionView search = (CollectionView)CollectionViewSource.GetDefaultView(studentList.ItemsSource);
            search.Filter = UserFilter;
        }

        #region Filter Methods
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(Search.Text))
            {
                return true;
            }
            else
            {
                return ((item as Student).LastName.IndexOf(Search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        } 
       
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(studentList.ItemsSource).Refresh();
        }
        #endregion

        #region Add click evernt handler
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            students.Add(new Student() { FirstName = FirstName.Text, LastName = LastName.Text, StudentId = StudentID.Text, StudentGpa = StudentGPA.Text });
            studentList.ItemsSource = students;
            CollectionViewSource.GetDefaultView(studentList.ItemsSource).Refresh();
        }
        #endregion

        #region Delete click event handler
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            students.Remove(studentList.SelectedItem as Student);
            studentList.ItemsSource = null;
            studentList.ItemsSource = students;
            studentList.Items.Refresh();
        }
        #endregion

        #region Logout click event handler
        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            Return(this, null);
            return;
        }
        #endregion

        #region Student Class
        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string StudentId { get; set; }
            public string StudentGpa { get; set; }

            public void ReportWriter()
            {
                StreamWriter reportWriter = new StreamWriter(@"C:\Data\Report");
                reportWriter.WriteLine("{0}, {1}, {2}, {3} ", FirstName, LastName, StudentId, StudentGpa);
                reportWriter.Close();
            }
        }

        #endregion

        private void writeFile_Click(object sender, RoutedEventArgs e)
        {
            var sortStudents = from student in students
                               orderby student.StudentGpa
                               select student;
            foreach (Student student in sortStudents)
            {
                student.ReportWriter();
            }
        }
       
    }
}
