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
    /// Логика взаимодействия для RedactPage.xaml
    /// </summary>
    public partial class RedactPage : Page
    {
        Pacient RedactPacient;
        public RedactPage(Pacient pacient)
        {
            RedactPacient = pacient;
            DataContext = RedactPacient;
            InitializeComponent();
    
        }

        private void Redactpacient(object sender, RoutedEventArgs e)
        {
          
            
                RedactPacient.UpdatePacient();

        }

        private void Back(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();

        }
    }
}
