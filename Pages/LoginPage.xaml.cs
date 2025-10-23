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

namespace WpfApp_DataBinding_Ver2.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        public void Login(object sender, RoutedEventArgs e)
        {

            var user = (User)Resources["UserLog"];
            if(user.Loadfromfile())
            {
                NavigationService.Navigate(new MainPage(user));
            }

        }
        public void Gotoregister(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new RegisterPage());
            
        }
    }
}
