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

namespace LogInPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LINQ_ConnectionDataContext db = new LINQ_ConnectionDataContext(Properties.Settings.Default.LINQLoginConnectionString);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (User_txt.Text == "|| pass_txt.Text == ") 
            {
                MessageBox.Show("Please enter username and password");
                return;
            }
            else 
            {

            }
            
        }
        private string getPassword()
        {
            string uPass = "";

            var users = (from u in db.User_Tables
                         where u.UserID == User_txt.Text
                         select u).FirstOrDefault();
            if (users == null)
            {
                MessageBox.Show("User not found.");
                return "";
            }
            uPass = users.UserPass;
            return uPass;
        }
        private int passComparison(string uPass)
        {
            if (Password_txt.Text == uPass)
            {
                return 0;
            }
            else if (uPass == null)
            {
                return -1;
            }
            else
                return 1;
        }
    }
}
