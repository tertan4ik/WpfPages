using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_DataBinding_Ver2.Pages;

namespace WpfApp_DataBinding_Ver2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        bool signin = false;
        bool register=false;
        bool pacientfind=false;
        public MainWindow()
        {
          


            InitializeComponent();
            MainFrame.Navigate(new LoginPage());

            ThemeHelper.ApplySavedTheme();

        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeHelper.ToggleTheme();
        }    


    }
}