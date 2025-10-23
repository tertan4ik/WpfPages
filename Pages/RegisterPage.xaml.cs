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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        User user=new User();
        public RegisterPage()
        {
            InitializeComponent();
            DataContext=user;
        }
        public void Registration(object sender, RoutedEventArgs e)
        {

            user.Savetofile();

        }

        public void Back(object sender, RoutedEventArgs e)
        {

         NavigationService.GoBack();

        }

    }
}
